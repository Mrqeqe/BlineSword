using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public Transform rightPoint;
    public Transform leftPoint;
    [Header("完美判定范围线（蓝）")]
    public float perfectJudgmentRange = 2.0f;
    [Header("普通判定范围线（绿）")]
    public float normalJugmentRange = 3.0f;
    [Header("判定区域背景开启/关闭")]
    public bool ShowBackground =true;
    [Header("UIScore对象")]
    public UIScore UIScore;
    [Header("是否开启震动")]
    public bool OpeanShake = true;
    [Header("屏幕震动时间")]
    [Range(0,1)]
    public float shakeDuration =0.5f;
    [Header("屏幕震动幅度")]
    [Range(0, 1)]
    public float shakeStrength = 0.5f;

    public Transform[] InsNoteTransList;
    /// <summary>
    /// 单例
    /// </summary>
    public static ScoringManager Instance { get; set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
  
    private void Start()
    {
       
     
    }
    private bool eventIsRisgested=false;
    private void Update()
    {
        if (NoteManger.Instance != null&&!eventIsRisgested)
        {
            NoteManger.Instance.OnperfectBeat += CameraShake;
            eventIsRisgested = true;
        }
    }

    /// <summary>
    /// 更新一次连击数
    /// </summary>
    public void UpdateBatterAction()
    {
       
       
          //  Debug.Log("连击");
            UIScore.NumOfHits += 1;
         
    }
    /// <summary>
    /// 中断连击
    /// </summary>
    public void InteruptBatterAction()
    {
        UIScore.NumOfHits = 0;
       // Debug.Log("中断连击");
    }


    /// <summary>
    /// 判定音符是否在完美判定区域
    /// </summary>
    /// <param name="currentNote">需要判定的音符</param>
    /// <returns></returns>
    public bool IsNoteInPerfectAera(GameObject currentNote)
    {
        Control myControl = currentNote.GetComponent<Control>();
        if (myControl.cirqueRadius <= perfectJudgmentRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 判断音符是否在普通区域
    /// </summary>
    /// <param name="currentNote">当前音符</param>
    /// <returns></returns>
    public bool IsNoteInNormalAera(GameObject currentNote)
    {
        
        Control myControl = currentNote.GetComponent<Control>();
        if (myControl.cirqueRadius > perfectJudgmentRange && myControl.cirqueRadius < normalJugmentRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

 
    /// <summary>
    /// 画出判定区域
    /// </summary>
    private void OnDrawGizmos()
    {
        if(leftPoint!=null&&rightPoint!=null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(rightPoint.position, perfectJudgmentRange);
            Gizmos.DrawWireSphere(leftPoint.position, perfectJudgmentRange);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(leftPoint.position, normalJugmentRange);
            Gizmos.DrawWireSphere(rightPoint.position, normalJugmentRange);
        }
        else
        {
            Debug.LogError("未获取到判定范围中心点");
        }
    }
    /// <summary>
    /// 屏幕震动
    /// </summary>
    private void CameraShake(Kore_EventNodeData data)
    {
        if(OpeanShake)
        {
            BeatSence.Instance.CameraShake(shakeDuration,shakeStrength);
        }
       
    }
     void OnValidate()
    {
       
        foreach (var item in InsNoteTransList)
        {
            
            if(ShowBackground)
            {
                 item.GetChild(0).gameObject.SetActive(true);
                 item.GetChild(1).gameObject.SetActive(true);
                item.GetChild(2).gameObject.SetActive(true);
                item.GetChild(0).localScale = new Vector3(perfectJudgmentRange * 2, perfectJudgmentRange * 2, 0.001f);
                item.GetChild(1).localScale = new Vector3(normalJugmentRange * 2, normalJugmentRange * 2, 0);
                item.GetChild(2).localScale = new Vector3(perfectJudgmentRange * 5, perfectJudgmentRange * 5, perfectJudgmentRange * 5);
            }
            else
            {
                item.GetChild(0).gameObject.SetActive(false);
                item.GetChild(1).gameObject.SetActive(false);
                item.GetChild(2).gameObject.SetActive(false);
                
            }
        }
    }
}
