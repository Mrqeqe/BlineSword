using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCondition : MonoBehaviour
{



    
    Transform myTrans;

    /// <summary>
    /// ��С�ٶ�
    /// </summary>
    private float shinkSpeed ;
    /// <summary>
    /// ����ģ�͵�Transform
    /// </summary>
    private Transform NoteModelTrans;
    /// <summary>
    /// ����Ԥ�����ݰ�
    /// </summary>
    private Kore_EventNodeData myNoteData;
    private Control myControl;
    /// <summary>
    /// ��¼��ʼBlur width1 ��ֵ
    /// </summary>
    private float _blurwidth1;
    private void Awake()
    {
        myControl = this.GetComponent<Control> ();
        myTrans = this.GetComponent<Transform>();
        myNoteData = this.GetComponent<Kore_EventNodeData>();
        NoteModelTrans = myTrans.GetChild(0);

        Initialize(myNoteData, NoteModelTrans);
    }
    void Start()
    {
        _blurwidth1 = myControl.cirqueBlurWidth;
        //ȷ��������ʼ�������ʾ
        Invoke("lateApperNote", 0.1f);
    }
    private void lateApperNote()
    {
        myTrans.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        myTrans.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
    }

    void Update()
    {

       
        NoteShink(shinkSpeed);
        //
        
    }
    /// <summary>
/// ������ģ�͸������ݰ���ʼ��
/// </summary>
/// <param name="myNoteData">���ݰ�</param>
/// <param name="NoteModelTrans">ģ��</param>
    private void Initialize(Kore_EventNodeData myNoteData,Transform NoteModelTrans)
    {
        shinkSpeed = myNoteData.NoteSpeed;
       
    }


    /// <summary>
    /// ������С����С��������
    /// </summary>
    /// <param name="shinkSpeed">��С�ٶ�</param>
    private void NoteShink(float shinkSpeed)
    {
        if (myControl.cirqueRadius < 0.01f)
        {

            if (myNoteData.NoteType != NoteManger.NoteType.DemonsNote)
            {
                ScoringManager.Instance.UIScore.CurentPlayerHealth -=NoteScoreData.Instance.Score.cutHealth;
            }

            ScoringManager.Instance.InteruptBatterAction();
            NoteManger.Instance.DestroyCurentNote();
        }

        myControl.cirqueRadius -= shinkSpeed*Time.deltaTime;
        myControl.haloRadius -= shinkSpeed * Time.deltaTime;

        myControl.cirqueWidth -=    myNoteData.NoteWithShinkSpeed * Time.deltaTime;

        //���뵭��
        if (myNoteData.IsFeadOut)
        {
            if (myControl.cirqueRadius <= myNoteData.TransLineIn && myControl.cirqueRadius > myNoteData.TransLineOut && myControl.cirqueBlurWidth < 30f)
            {
                myControl.cirqueBlurWidth += myNoteData.TransInSpeed * Time.deltaTime;

            }
            else if (myControl.cirqueRadius <= myNoteData.TransLineOut && myControl.cirqueBlurWidth > _blurwidth1)
            {
                myControl.cirqueBlurWidth -= myNoteData.TransOutSpeed * Time.deltaTime;
            }
        }
       
       
    }
    /// <summary>
    /// ��ħ����������Ϊ
    /// </summary>
    public void DemoNoteBehavior()
    {
      if(myNoteData.NoteType == NoteManger.NoteType.DemonsNote)
        {
           
        }
       
    }
    
    
}
