using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kore_EventNodeData : MonoBehaviour
{
    /// <summary>
    /// 音符位置枚举
    /// </summary>
   public  enum NotePostion
    {
        Pos_1=0,Pos_2=1,Pos_3=2,Pos_4=3,Pos_5=4,Pos_6=5,Pos_7=6,Pos_8=7,
    }

    [Header("判定与实际参数")]
    [Tooltip("生成位置")]
    [SerializeField]
    private NotePostion noteInsPostion;
    
    [Tooltip("音符种类")]
    [SerializeField]
    private NoteManger.NoteType noteType;

    [Tooltip("音效种类")]
    [SerializeField]
    private NoteManger.SFX_Type sfxType;

    [Tooltip("音效音调")]
    [SerializeField]
    private NoteManger.tone noteTone;

    [Tooltip("初始音符宽度缩小速度")]
    [SerializeField]
    private float noteWithShinkSpeed =0.7f;    
    
    [Tooltip("音符速度")]
    [SerializeField]
    private float noteSpeed = 1.0f;


    [Header("显示效果")]
    [Space]
    [SerializeField]
    [Tooltip("是否开启")]
    private bool isFeadOut = false;
    [Space]
    [Tooltip("淡入线")]
    [SerializeField]
    private float transLineIn =2.0f;
   
    [Tooltip("淡出线")]
    [SerializeField]
    private float transLineOut = 0.86f;
  
    [Tooltip("音符淡入速度")]
    [SerializeField]
    private float transInSpeed = 50.0f;

    [Tooltip("音符淡出速度")]
    [SerializeField]
    private float transOutSpeed = 70.0f;
   
    //[Header("分数相关")]

    //[Tooltip("音符完美击败得分")]
    //[SerializeField]
    //private float perfectBeatScore = 10.0f;
   
    //[Tooltip("音符普通击败得分")]
    //[SerializeField]
    //private float normalBeatScore = 5.0f;
   
    //[Tooltip("音符失败扣除血量")]
    //[SerializeField]
    //private float cutHealth = 10.0f;
    
    //[Tooltip("音符完美剑心得分")]
    //[SerializeField]
    //private float perfectSwordHeartScore = 10.0f;
   
    //[Tooltip("音符普通剑心得分")]
    //[SerializeField]
    //private float normalSwordHeartScore = 5.0f;

    //[Tooltip("心魔增加值")]
    //[SerializeField]
    //private float heartDemoScore =10.0f;
    /// <summary>
    /// 生成位置
    /// </summary>
    public NotePostion NoteInsPostion { get => noteInsPostion; set => noteInsPostion = value; }
    /// <summary>
    /// 音符种类
    /// </summary>
    public NoteManger.NoteType NoteType { get => noteType; set => noteType = value; }
    /// <summary>
    /// 初始音符模型半径（非判定半径）
    /// </summary>
    public float NoteWithShinkSpeed { get => noteWithShinkSpeed; set => noteWithShinkSpeed = value; }
    /// <summary>
    /// 音符速度
    /// </summary>
    public float NoteSpeed { get => noteSpeed; set => noteSpeed = value; }
    /// <summary>
    /// 音符淡入淡出速度
    /// </summary>
    public float TransInSpeed { get => transInSpeed; set => transInSpeed = value; }
    /// <summary>
    /// 音符淡出速度
    /// </summary>
    public float TransOutSpeed { get => transOutSpeed; set => transOutSpeed = value; }
    /// <summary>
    /// 音符完美击败得分
    /// </summary>
    //public float PerfectBeatScore { get => perfectBeatScore; set => perfectBeatScore = value; }
    ///// <summary>
    ///// 音符普通击败得分
    ///// </summary>
    //public float NormalBeatScore { get => normalBeatScore; set => normalBeatScore = value; }
    ///// <summary>
    ///// 音符失败扣除血量
    ///// </summary>
    //public float CutHealth { get => cutHealth; set => cutHealth = value; }
    ///// <summary>
    ///// 音符完美剑心得分
    ///// </summary>
    //public float PerfectSwordHeartScore { get => perfectSwordHeartScore; set => perfectSwordHeartScore = value; }
    ///// <summary>
    ///// 音符普通剑心得分
    ///// </summary>
    //public float NormalSwordHeartScore { get => normalSwordHeartScore; set => normalSwordHeartScore = value; }
    ///// <summary>
    ///// 心魔音符分数
    ///// </summary>
    //public float HeartDemoScore { get => heartDemoScore; set => heartDemoScore = value; }
    /// <summary>
    /// 音效种类
    /// </summary>
    public NoteManger.SFX_Type SfxType { get => sfxType; set => sfxType = value; }
    /// <summary>
    /// 淡入开始线
    /// </summary>
    public float TransLineIn { get => transLineIn; set => transLineIn = value; }
    /// <summary>
    /// 淡出开始线
    /// </summary>
    public float TransLineOut { get => transLineOut; set => transLineOut = value; }
    /// <summary>
    /// 是否开器淡出效果
    /// </summary>
    public bool IsFeadOut { get => isFeadOut; set => isFeadOut = value; }
    /// <summary>
    /// 音调种类
    /// </summary>
    public NoteManger.tone NoteTone { get => noteTone; set => noteTone = value; }

    private void OnDrawGizmosSelected()
    {

        Vector3 rithtPoint = new Vector3(4, 0, 0);
        Vector3 leftPoint = new Vector3(-4, 0, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rithtPoint, TransLineIn);
        Gizmos.DrawWireSphere(leftPoint, TransLineIn);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rithtPoint, TransLineOut);
        Gizmos.DrawWireSphere(leftPoint, TransLineOut);
    }
   
}
