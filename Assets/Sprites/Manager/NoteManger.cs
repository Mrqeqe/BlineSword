using SonicBloom.Koreo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManger : MonoBehaviour
{
    /// <summary>
    /// ����������
    /// </summary>
    public  static NoteManger Instance { get; set; }

    public string eventID;

    public Transform[] InsPostionList;

    [Header("������Ч��������Ч��ǿ��")]
    [Range(0,1)]
    public float steroPan = 0f;
    /// <summary>
    /// ��������ö��
    /// </summary>
    public enum NoteType
    {
        NormalNote,
      
        DemonsNote,

    }
    public enum SFX_Type
    {
        Sword,
        Wood,
        Flash,
    }
    /// <summary>
    /// �洢��ǰ���������ɡ�δ���ٵ�����
    /// </summary>
    private List<GameObject> CurentNoteList = new List<GameObject>();

    private void Awake()
    {
        if(Instance !=null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        Koreographer.Instance.RegisterForEvents(eventID, CreatANote);
    }


     void Start()
     {
        InputManager.Instance.OnKeyPassed += MouseClickedEventHandler;
      
     }
    /// <summary>
    /// OnMouseCLicked������,��ͬ�������߼�����
    /// </summary>
    /// <param name="playerInput"></param>
    private void MouseClickedEventHandler(InputManager.PlayerInput playerInput)
    {
       
        GameObject note = GetCurrentNote();                              //��ȡ��ǰ����
        if (note != null)
        {
            Kore_EventNodeData noteData = note.GetComponent<Kore_EventNodeData>();

            NoteAction(noteData, playerInput, note);
        }
    }

    /// <summary>
    /// ����������Ϊ,�жϵ��ʱ�����ôε���Ƿ����� ��������UIֵ
    /// </summary>
    /// <param name="noteData"></param>
    /// <param name="playerInput"></param>
    private void NoteAction(Kore_EventNodeData noteData,InputManager.PlayerInput playerInput,GameObject note)
    {
       
        if (IsRightKeyPress(noteData, playerInput))
        {   
            if(noteData.NoteType == NoteType.DemonsNote)
            {
               ScoringManager.Instance.UIScore.CurentHeartDemonSCore +=noteData.HeartDemoScore;
                ScoringManager.Instance.InteruptBatterAction();
                Debug.Log("������");
                DestroyCurentNote();
                
            }
            //�����ж�
            else if (ScoringManager.Instance.IsNoteInPerfectAera(note))
            {
                PlayCorrespondAudio(noteData);
                ScoringManager.Instance.UIScore.CurentSwordHeartScore += noteData.PerfectSwordHeartScore;
                ScoringManager.Instance.UIScore.PlayerScore += noteData.PerfectBeatScore;
                ScoringManager.Instance.UpdateBatterAction();
                DestroyCurentNote();
            }
            //��ͨ�ж�
            else if (ScoringManager.Instance.IsNoteInNormalAera(note))
            {
                PlayCorrespondAudio(noteData);
                ScoringManager.Instance.UIScore.CurentSwordHeartScore += noteData.NormalSwordHeartScore;
                ScoringManager.Instance.UIScore.PlayerScore += noteData.NormalBeatScore;
                ScoringManager.Instance.UpdateBatterAction();
                DestroyCurentNote();
            }
            else
            {
                //TODO:Miss����
                Debug.Log("Miss");
                DestroyCurentNote();
                ScoringManager.Instance.InteruptBatterAction();
                ScoringManager.Instance.UIScore.CurentPlayerHealth -= noteData.CutHealth;
                ScoringManager.Instance.InteruptBatterAction();

            }
        }
    }
    /// <summary>
    /// ���Ŷ�Ӧ��Ч
    /// </summary>
    /// <param name="noteData">��������</param>
    private void PlayCorrespondAudio(Kore_EventNodeData noteData)
    {
       
        if(noteData.NoteInsPostion == Kore_EventNodeData.NotePostion.Pos_1)
        {
            steroPan = -0.8f;
        }
        else if(noteData.NoteInsPostion == Kore_EventNodeData.NotePostion.Pos_2)
        {
            steroPan = 0.8f;
        }
        switch(noteData.SfxType)
        {
            case SFX_Type.Flash:
                AudioManager.GetAudioSoure(AudioName.FlashSFX).panStereo = steroPan;
                AudioManager.PlayAudio(AudioName.FlashSFX);
                break;
            case SFX_Type.Sword:
                AudioManager.GetAudioSoure(AudioName.SwordSFX).panStereo = steroPan;
                AudioManager.PlayAudio(AudioName.SwordSFX);
                break;
            case SFX_Type.Wood:
                AudioManager.GetAudioSoure(AudioName.WoodSFX).panStereo = steroPan;
                AudioManager.PlayAudio(AudioName.WoodSFX);
                break;
        }
    }
    /// <summary>
    /// �ж�����ö���Ƿ��ܺ�������Ӧ�ϣ����Ƿ�����ȷ
    /// </summary>
    /// <param name="noteData">�������ݰ�</param>
    /// <param name="playerInput">����ö��ֵ</param>
    /// <returns></returns>
    private bool IsRightKeyPress(Kore_EventNodeData noteData, InputManager.PlayerInput playerInput)
    {
        
        
            if (((int)noteData.NoteInsPostion) == ((int)playerInput) )
            {
                return true;

            }
            else
            {
                return false;
            }
      
    
       
    }

    /// <summary>
    /// ���ٵ�ǰ������ִ��һЩ����
    /// </summary>
    public  void DestroyCurentNote()
    {
        //��ȡ��ǰӦ���ٵ�����
        GameObject note = GetCurrentNote();
        if(note == null )
        {
            Debug.LogWarning("��ǰ������");
            return;
        }
       
        // Debug.Log("ɾ��������" + note.name);
        //ɾ��List�е�ǰ����
        CurentNoteListRemove(note);
        
        //ɾ�������е�ǰ����
        Destroy(note);
    }

    /// <summary>
    /// ��ȡ��ǰӦ���������
    /// </summary>
    /// <returns></returns>
    public GameObject GetCurrentNote()
    {
        if(CurentNoteList.Count!=0)
        {
            return CurentNoteList[0];
        }
        Debug.LogWarning("��ǰ�б�������return null");
        return null ;
    }

    /// <summary>
    /// ����������뵱ǰ�����б�
    /// </summary>
    /// <param name="note">����</param>
    private void CurentNoteListAdd(GameObject note)
    {
        CurentNoteList.Add(note);
    }


    /// <summary>
    /// �������Ƴ���ǰ�����б�
    /// </summary>
    /// <param name="note">����</param>
    private void CurentNoteListRemove(GameObject note)
    {
        CurentNoteList.Remove(note);
    }

    /// <summary>
    /// ����һ��������
    /// </summary>
    /// <param name="koreoEvent">��������</param>
    private void CreatANote(KoreographyEvent koreoEvent)
    {
        GameObject note =  CreatANoteINSence(koreoEvent);
        CurentNoteListAdd(note);
    }


    /// <summary>
    /// �ڳ���������һ��������ֻ��������������λ������ѡ��Ĭ��Ϊ��
    /// </summary>
    /// <param name="koreoEvent"></param>
    private GameObject CreatANoteINSence(KoreographyEvent koreoEvent)
    {
        
        if (koreoEvent.GetAssetValue() != null)
        {
            
            GameObject notePerfab = koreoEvent.GetAssetValue() as GameObject;
            if (notePerfab != null)
            {
                int index = ((int)notePerfab.GetComponent<Kore_EventNodeData>().NoteInsPostion);
                GameObject note = GameObject.Instantiate(notePerfab, InsPostionList[index].position, Quaternion.identity);                   
                return note;
            }
            else
            {
                Debug.LogWarning("��������Ԥ����Ϊ��,δ�ɹ���������");
                return null;
            }
        }                                              
        else
        {
            Debug.LogWarning("����������ԴΪ��,δ�ɹ���������");
            return null;
            
        }
    }
  

    
}
