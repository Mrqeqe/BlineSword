using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public Transform rightPoint;
    public Transform leftPoint;
    [Header("�����ж���Χ�ߣ�����")]
    public float perfectJudgmentRange = 2.0f;
    [Header("��ͨ�ж���Χ�ߣ��̣�")]
    public float normalJugmentRange = 3.0f;
    [Header ("�ж�ƫ����")]
    public float offestJugmentRange = 0.1f;
    [Header("�ж����򱳾�����/�ر�")]
    public bool ShowBackground =true;
    [Header("UIScore����")]
    public UIScore UIScore;
    [Header("�Ƿ�����")]
    public bool OpeanShake = true;
    [Header("Sword��Ļ��ʱ��")]
    [Range(0,1)]
    public float swordShakeDuration =0.5f;
    [Header("Sword��Ļ�𶯷���")]
    [Range(0, 1)]
    public float swordShakeStrength = 0.5f;
    [Header("Flash��Ļ��ʱ��")]
    [Range(0,1)]
    public float flashShakeDuration =0.5f;
    [Header("Flash��Ļ�𶯷���")]
    [Range(0, 1)]
    public float flashShakeStrength = 0.5f;
    [Header("Hit��Ļ��ʱ��")]
    [Range(0,1)]
    public float hitShakeDuration =0.5f;
    [Header("Hit��Ļ�𶯷���")]
    [Range(0, 1)]
    public float hitShakeStrength = 0.5f;
   
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
        if (myControl.cirqueRadius <= perfectJudgmentRange+ offestJugmentRange)
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
        if (myControl.cirqueRadius > perfectJudgmentRange && myControl.cirqueRadius < normalJugmentRange+ offestJugmentRange)
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
            Gizmos.DrawWireSphere(rightPoint.position, perfectJudgmentRange+ offestJugmentRange);
            Gizmos.DrawWireSphere(leftPoint.position, perfectJudgmentRange + offestJugmentRange);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(leftPoint.position, normalJugmentRange + offestJugmentRange);
            Gizmos.DrawWireSphere(rightPoint.position, normalJugmentRange + offestJugmentRange);
        }
        else
        {
            Debug.LogError("δ��ȡ���ж���Χ���ĵ�");
        }
    }
    /// <summary>
    /// ��Ļ��
    /// </summary>
    private void CameraShake(Kore_EventNodeData data)
    {
        if(OpeanShake)
        {
            switch(data.SfxType)
            {
                case NoteManger.SFX_Type.Sword: BeatSence.Instance.CameraShake(swordShakeDuration, swordShakeStrength);
                    break;
                case NoteManger.SFX_Type.Hit:BeatSence.Instance.CameraShake(hitShakeDuration, hitShakeStrength);
                    break;
                case NoteManger.SFX_Type.Flash:BeatSence.Instance.CameraShake(flashShakeDuration, flashShakeStrength);
                    break;
            }
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
