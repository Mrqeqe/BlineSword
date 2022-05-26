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

    public Transform[] InsPostionList;

    public Action <Kore_EventNodeData> OnperfectBeat;
    [Header("音符音效左右声道效果强度")]
    [Range(0,1)]
    public float steroPan = 0f;
    /// <summary>
    /// 音符种类枚举
    /// </summary>
    public enum NoteType
    {
        NormalNote,
      
        DemonsNote,

    }
    public enum SFX_Type
    {
        Sword,
        Hit,
        Flash,
    }
    public enum tone
    {
         do_1, re_2, mi_3, fa_4, sol_5, la_6, si_7
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
        InputManager.Instance.OnKeyPassed += MouseClickedEventHandler;
      
     }
    /// <summary>
    /// OnMouseCLicked处理器,不同音符的逻辑调用
    /// </summary>
    /// <param name="playerInput"></param>
    private void MouseClickedEventHandler(InputManager.PlayerInput playerInput)
    {
       
        GameObject note = GetCurrentNote();                              //获取当前音符
        if (note != null)
        {
            Kore_EventNodeData noteData = note.GetComponent<Kore_EventNodeData>();

            NoteAction(noteData, playerInput, note);
        }
    }

    /// <summary>
    /// 音符基本行为,判断点击时机，该次点击是否连击 更新所有UI值
    /// </summary>
    /// <param name="noteData"></param>
    /// <param name="playerInput"></param>
    private void NoteAction(Kore_EventNodeData noteData,InputManager.PlayerInput playerInput,GameObject note)
    {
       
        if (IsRightKeyPress(noteData, playerInput))
        {   
            if(noteData.NoteType == NoteType.DemonsNote)
            {
               ScoringManager.Instance.UIScore.CurentHeartDemonSCore += NoteScoreData.Instance.Score.heartDemoScore;
                ScoringManager.Instance.InteruptBatterAction();
                Debug.Log("中招了");
                DestroyCurentNote();
               
            }
            //完美判断
            else if (ScoringManager.Instance.IsNoteInPerfectAera(note))
            {
                OnperfectBeat.Invoke(noteData);
                PlayCorrespondAudio(noteData);
                ScoringManager.Instance.UIScore.CurentSwordHeartScore +=  NoteScoreData.Instance.Score.perfectSwordHeartScore;
                ScoringManager.Instance.UIScore.PlayerScore +=  NoteScoreData.Instance.Score.perfectBeatScore;
                ScoringManager.Instance.UpdateBatterAction();
                DestroyCurentNote();
            }
            //普通判断
            else if (ScoringManager.Instance.IsNoteInNormalAera(note))
            {
                PlayCorrespondAudio(noteData);
                ScoringManager.Instance.UIScore.CurentSwordHeartScore +=  NoteScoreData.Instance.Score.normalSwordHeartScore;
                ScoringManager.Instance.UIScore.PlayerScore += NoteScoreData.Instance.Score.normalBeatScore;
                ScoringManager.Instance.UpdateBatterAction();
                DestroyCurentNote();
            }
            else
            {
                //TODO:Miss操作
                Debug.Log("Miss");
                DestroyCurentNote();
                ScoringManager.Instance.InteruptBatterAction();
                ScoringManager.Instance.UIScore.CurentPlayerHealth -= NoteScoreData.Instance.Score.cutHealth;
                ScoringManager.Instance.InteruptBatterAction();

            }
        }
    }
    /// <summary>
    /// 播放对应音效
    /// </summary>
    /// <param name="noteData">音符数据</param>
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
               switch(noteData.NoteTone)
                {
                    case tone.do_1:
                        AudioManager.PlayAudio(AudioName.Flash_1);
                        break;
                    case tone.re_2:
                        AudioManager.PlayAudio(AudioName.Flash_2);
                        break;
                    case tone.mi_3:
                        AudioManager.PlayAudio(AudioName.Flash_3);
                        break;
                    case tone.fa_4:
                        AudioManager.PlayAudio(AudioName.Flash_4);
                        break;
                    case tone.sol_5:
                        AudioManager.PlayAudio(AudioName.Flash_5);
                        break;
                    case tone.la_6:
                        AudioManager.PlayAudio(AudioName.Flash_6);
                        break;
                    case tone.si_7:
                        AudioManager.PlayAudio(AudioName.Flash_7);
                        break;

                }
                break;
            case SFX_Type.Sword:

                switch (noteData.NoteTone)
                {
                    case tone.do_1:
                        Debug.Log("播放");
                        AudioManager.PlayAudio(AudioName.Sword_1);
                        break;                           
                    case tone.re_2:                      
                        AudioManager.PlayAudio(AudioName.Sword_2);
                        break;                           
                    case tone.mi_3:                      
                        AudioManager.PlayAudio(AudioName.Sword_3);
                        break;                           
                    case tone.fa_4:                      
                        AudioManager.PlayAudio(AudioName.Sword_4);
                        break;                           
                    case tone.sol_5:                      
                        AudioManager.PlayAudio(AudioName.Sword_5);
                        break;                           
                    case tone.la_6:                      
                        AudioManager.PlayAudio(AudioName.Sword_6);
                        break;
                    case tone.si_7:
                        AudioManager.PlayAudio(AudioName.Sword_7);
                        break;
                }
                break;
            case SFX_Type.Hit:
                switch (noteData.NoteTone)
                {
                    case tone.do_1:
                        AudioManager.PlayAudio(AudioName.Hit_1);
                        break;
                    case tone.re_2:
                        AudioManager.PlayAudio(AudioName.Hit_2);
                        break;
                    case tone.mi_3:
                        AudioManager.PlayAudio(AudioName.Hit_3);
                        break;
                    case tone.fa_4:
                        AudioManager.PlayAudio(AudioName.Hit_4);
                        break;
                    case tone.sol_5:
                        AudioManager.PlayAudio(AudioName.Hit_5);
                        break;
                    case tone.la_6:
                        AudioManager.PlayAudio(AudioName.Hit_6);
                        break;
                    case tone.si_7:
                        AudioManager.PlayAudio(AudioName.Hit_7);
                        break;
                }
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
    /// 销毁当前音符并执行一些操作
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
    /// 在场景中生成一个音符，
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
               //唤起完美喷溅粒子
              InsPostionList[index].GetChild(3).gameObject.SetActive(true);
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
