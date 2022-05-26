using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCondition : MonoBehaviour
{



    
    Transform myTrans;

    /// <summary>
    /// 缩小速度
    /// </summary>
    private float shinkSpeed ;
    /// <summary>
    /// 音符模型的Transform
    /// </summary>
    private Transform NoteModelTrans;
    /// <summary>
    /// 音符预置数据包
    /// </summary>
    private Kore_EventNodeData myNoteData;
    private Control myControl;
    /// <summary>
    /// 记录开始Blur width1 的值
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
        //确保音符初始化后才显示
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
/// 将音符模型根据数据包初始化
/// </summary>
/// <param name="myNoteData">数据包</param>
/// <param name="NoteModelTrans">模型</param>
    private void Initialize(Kore_EventNodeData myNoteData,Transform NoteModelTrans)
    {
        shinkSpeed = myNoteData.NoteSpeed;
       
    }


    /// <summary>
    /// 音符缩小、最小化后销毁
    /// </summary>
    /// <param name="shinkSpeed">缩小速度</param>
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

        //淡入淡出
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
    /// 恶魔音符额外行为
    /// </summary>
    public void DemoNoteBehavior()
    {
      if(myNoteData.NoteType == NoteManger.NoteType.DemonsNote)
        {
           
        }
       
    }
    
    
}
