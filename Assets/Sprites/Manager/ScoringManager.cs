using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public Transform rightPoint;
    public Transform leftPoint;
    [Header("完美判定范围线（蓝）")]
    public float perfectJudgmentRange = 2.0f;
    [Header("普通判定范围线（绿）")]
    public float normalJugmentRange = 3.0f;
  
    [Header("UIScore对象")]


    public UIScore UIScore;

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
    private void Update()
    {

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
    private void OnDrawGizmosSelected()
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
}
