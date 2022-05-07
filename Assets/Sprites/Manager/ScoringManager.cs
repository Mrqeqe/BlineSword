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
     void OnValidate()
    {
       
        foreach (var item in InsNoteTransList)
        {
            
            if(ShowBackground)
            {
                 item.GetChild(0).gameObject.SetActive(true);
                 item.GetChild(1).gameObject.SetActive(true);
                item.GetChild(2).gameObject.SetActive(true);
                item.GetChild(0).localScale = new Vector3(perfectJudgmentRange * 2, perfectJudgmentRange * 2, perfectJudgmentRange * 2);
                item.GetChild(1).localScale = new Vector3(normalJugmentRange * 2, normalJugmentRange * 2, 0);
                item.GetChild(2).localScale = new Vector3(perfectJudgmentRange * 4, perfectJudgmentRange * 4, 1);
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
