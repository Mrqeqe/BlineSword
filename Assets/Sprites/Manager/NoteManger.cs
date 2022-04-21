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
    [Header("�������ɵ㣺��")]
    public Transform leftInsTrans;
    [Header("�������ɵ㣺��")]
    public Transform rightInsTrans;
    /// <summary>
    /// ��������ö��
    /// </summary>
    public enum NoteType
    {
        NormalNote,
        LongNote,
        DemonsNote,
        DoubleNote,
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
        InputManager.Instance.OnMouseClicked += MouseClickedEventHandler;
      
     }
    /// <summary>
    /// OnMouseCLicked������,��ͬ�������߼�����
    /// </summary>
    /// <param name="playerInput"></param>
    private void MouseClickedEventHandler(InputManager.PlayerInput playerInput)
    {
       
        GameObject note = GetCurrentNote();                              //��ȡ��ǰ����
        if(note !=null)
        {
            Kore_EventNodeData noteData = note.GetComponent<Kore_EventNodeData>();
            switch (noteData.NoteType)       //�ж���������
            {
                case NoteType.NormalNote: //������ͨ�����߼�
                                          //�ж��Ƿ�����ȷ����


                    //TODO:��ͨ�����Ƿ�
                    //��������
                    NoteBaseAction( noteData,  playerInput,  note);
                    break;
                case NoteType.LongNote:          //TODO:�����������߼�
                    break;
                case NoteType.DemonsNote:     
                        //TODO:��ħϵͳ
                  
                    NoteBaseAction(noteData, playerInput, note);
                 
                    break;
                case NoteType.DoubleNote:

                    //TODO:˫�����߼�

                    NoteBaseAction(noteData, playerInput, note);
                    break;
            }
        }
        //�жϵ÷�
    }

    /// <summary>
    /// �������������еĻ�����Ϊ,�жϵ��ʱ�����ôε���Ƿ����� ��������UIֵ
    /// </summary>
    /// <param name="noteData"></param>
    /// <param name="playerInput"></param>
    private void NoteBaseAction(Kore_EventNodeData noteData,InputManager.PlayerInput playerInput,GameObject note)
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

    private void PlayCorrespondAudio(Kore_EventNodeData noteData)
    {
        switch(noteData.SfxType)
        {
            case SFX_Type.Flash:
                AudioManager.PlayAudio(AudioName.FlashSFX);
                break;
            case SFX_Type.Sword:AudioManager.PlayAudio(AudioName.SwordSFX);
                break;
            case SFX_Type.Wood: AudioManager.PlayAudio(AudioName.WoodSFX);
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
        if(noteData.NoteType == NoteType.DoubleNote)
        {
            
            if (playerInput == InputManager.PlayerInput.Mouseboth)
            {
             
                return true;
              
            }
            else
            {
               
                return false;
            }
         
        }
        else
        {
            if (noteData.NoteInsPostion == Kore_EventNodeData.NotePostion.left && playerInput == InputManager.PlayerInput.Mouseleft
             || noteData.NoteInsPostion == Kore_EventNodeData.NotePostion.right && playerInput == InputManager.PlayerInput.Mouseright
                )
            {
                return true;

            }
            else
            {
                return false;
            }
      
        }
       
    }

    /// <summary>
    /// ���ٵ�ǰ����
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
            if(notePerfab !=null)
            {
              
                
                Vector3 noteInsPostion = leftInsTrans.position;//Ĭ��Ϊ���λ��
                if (notePerfab.GetComponent<Kore_EventNodeData>().NoteInsPostion == Kore_EventNodeData.NotePostion.right)
                {
                    noteInsPostion = rightInsTrans.position;
                }

                GameObject note = GameObject.Instantiate(notePerfab, noteInsPostion, Quaternion.identity);                   
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
