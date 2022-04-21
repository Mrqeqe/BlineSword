using SonicBloom.Koreo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManger : MonoBehaviour
{
    /// <summary>
    /// 音符管理单例
    /// </summary>
    public  static NoteManger Instance { get; set; }

    public string eventID;
    [Header("音符生成点：左")]
    public Transform leftInsTrans;
    [Header("音符生成点：右")]
    public Transform rightInsTrans;
    /// <summary>
    /// 音符种类枚举
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
    /// 存储当前已生成生成、未销毁的音符
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
    /// OnMouseCLicked处理器,不同音符的逻辑调用
    /// </summary>
    /// <param name="playerInput"></param>
    private void MouseClickedEventHandler(InputManager.PlayerInput playerInput)
    {
       
        GameObject note = GetCurrentNote();                              //获取当前音符
        if(note !=null)
        {
            Kore_EventNodeData noteData = note.GetComponent<Kore_EventNodeData>();
            switch (noteData.NoteType)       //判断音符种类
            {
                case NoteType.NormalNote: //触发普通音符逻辑
                                          //判断是否按下正确按键


                    //TODO:普通音符记分
                    //销毁音符
                    NoteBaseAction( noteData,  playerInput,  note);
                    break;
                case NoteType.LongNote:          //TODO:触发长音符逻辑
                    break;
                case NoteType.DemonsNote:     
                        //TODO:心魔系统
                  
                    NoteBaseAction(noteData, playerInput, note);
                 
                    break;
                case NoteType.DoubleNote:

                    //TODO:双音符逻辑

                    NoteBaseAction(noteData, playerInput, note);
                    break;
            }
        }
        //判断得分
    }

    /// <summary>
    /// 所有音符都具有的基本行为,判断点击时机，该次点击是否连击 更新所有UI值
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
                Debug.Log("中招了");
                DestroyCurentNote();
                
            }
            //完美判断
            else if (ScoringManager.Instance.IsNoteInPerfectAera(note))
            {
                PlayCorrespondAudio(noteData);
                ScoringManager.Instance.UIScore.CurentSwordHeartScore += noteData.PerfectSwordHeartScore;
                ScoringManager.Instance.UIScore.PlayerScore += noteData.PerfectBeatScore;
                ScoringManager.Instance.UpdateBatterAction();
                DestroyCurentNote();
            }
            //普通判断
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
                //TODO:Miss操作
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
    /// 判断输入枚举是否能和音符对应上，即是否点击正确
    /// </summary>
    /// <param name="noteData">音符数据包</param>
    /// <param name="playerInput">键入枚举值</param>
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
    /// 销毁当前音符
    /// </summary>
    public  void DestroyCurentNote()
    {
        //获取当前应销毁的音符
        GameObject note = GetCurrentNote();
        if(note == null )
        {
            Debug.LogWarning("当前无音符");
            return;
        }
       // Debug.Log("删除音符：" + note.name);
        //删除List中当前音符
        CurentNoteListRemove(note);
        //删除场景中当前音符
        Destroy(note);
    }

    /// <summary>
    /// 获取当前应点击的音符
    /// </summary>
    /// <returns></returns>
    public GameObject GetCurrentNote()
    {
        if(CurentNoteList.Count!=0)
        {
            return CurentNoteList[0];
        }
        Debug.LogWarning("当前列表无音符return null");
        return null ;
    }

    /// <summary>
    /// 将音符添加入当前音符列表
    /// </summary>
    /// <param name="note">音符</param>
    private void CurentNoteListAdd(GameObject note)
    {
        CurentNoteList.Add(note);
    }


    /// <summary>
    /// 将音符移除当前音符列表
    /// </summary>
    /// <param name="note">音符</param>
    private void CurentNoteListRemove(GameObject note)
    {
        CurentNoteList.Remove(note);
    }

    /// <summary>
    /// 创建一个新音符
    /// </summary>
    /// <param name="koreoEvent">创建依据</param>
    private void CreatANote(KoreographyEvent koreoEvent)
    {
        GameObject note =  CreatANoteINSence(koreoEvent);
        CurentNoteListAdd(note);
    }


    /// <summary>
    /// 在场景中生成一个音符，只会生成左右两个位置其他选项默认为左
    /// </summary>
    /// <param name="koreoEvent"></param>
    private GameObject CreatANoteINSence(KoreographyEvent koreoEvent)
    {
        
        if (koreoEvent.GetAssetValue() != null)
        {
            
            GameObject notePerfab = koreoEvent.GetAssetValue() as GameObject;
            if(notePerfab !=null)
            {
              
                
                Vector3 noteInsPostion = leftInsTrans.position;//默认为左边位置
                if (notePerfab.GetComponent<Kore_EventNodeData>().NoteInsPostion == Kore_EventNodeData.NotePostion.right)
                {
                    noteInsPostion = rightInsTrans.position;
                }

                GameObject note = GameObject.Instantiate(notePerfab, noteInsPostion, Quaternion.identity);                   
                return note;
            }
            else
            {
                Debug.LogWarning("传入音符预制体为空,未成功生成音符");
                return null;
            }
        }                                              
        else
        {
            Debug.LogWarning("传入音符资源为空,未成功生成音符");
            return null;
            
        }
    }
  

    
}
