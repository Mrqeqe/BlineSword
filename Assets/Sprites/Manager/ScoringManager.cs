using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public Transform rightPoint;
    public Transform leftPoint;
    [Header("�����ж���Χ�ߣ�����")]
    public float perfectJudgmentRange = 2.0f;
    [Header("��ͨ�ж���Χ�ߣ��̣�")]
    public float normalJugmentRange = 3.0f;
  
    [Header("UIScore����")]


    public UIScore UIScore;

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
            Debug.LogError("δ��ȡ���ж���Χ���ĵ�");
        }
    }
}
