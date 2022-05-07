using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public Transform rightPoint;
    public Transform leftPoint;
    [Header("�����ж���Χ�ߣ�����")]
    public float perfectJudgmentRange = 2.0f;
    [Header("��ͨ�ж���Χ�ߣ��̣�")]
    public float normalJugmentRange = 3.0f;
    [Header("�ж����򱳾�����/�ر�")]
    public bool ShowBackground =true;
    [Header("UIScore����")]
    public UIScore UIScore;

    public Transform[] InsNoteTransList;
    /// <summary>
    /// ����
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
    /// ����һ��������
    /// </summary>
    public void UpdateBatterAction()
    {
       
       
          //  Debug.Log("����");
            UIScore.NumOfHits += 1;
         
    }
    /// <summary>
    /// �ж�����
    /// </summary>
    public void InteruptBatterAction()
    {
        UIScore.NumOfHits = 0;
       // Debug.Log("�ж�����");
    }


    /// <summary>
    /// �ж������Ƿ��������ж�����
    /// </summary>
    /// <param name="currentNote">��Ҫ�ж�������</param>
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
    /// �ж������Ƿ�����ͨ����
    /// </summary>
    /// <param name="currentNote">��ǰ����</param>
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
    /// �����ж�����
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
            Debug.LogError("δ��ȡ���ж���Χ���ĵ�");
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
