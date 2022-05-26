using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kore_EventNodeData : MonoBehaviour
{
    /// <summary>
    /// ����λ��ö��
    /// </summary>
   public  enum NotePostion
    {
        Pos_1=0,Pos_2=1,Pos_3=2,Pos_4=3,Pos_5=4,Pos_6=5,Pos_7=6,Pos_8=7,
    }

    [Header("�ж���ʵ�ʲ���")]
    [Tooltip("����λ��")]
    [SerializeField]
    private NotePostion noteInsPostion;
    
    [Tooltip("��������")]
    [SerializeField]
    private NoteManger.NoteType noteType;

    [Tooltip("��Ч����")]
    [SerializeField]
    private NoteManger.SFX_Type sfxType;

    [Tooltip("��Ч����")]
    [SerializeField]
    private NoteManger.tone noteTone;

    [Tooltip("��ʼ���������С�ٶ�")]
    [SerializeField]
    private float noteWithShinkSpeed =0.7f;    
    
    [Tooltip("�����ٶ�")]
    [SerializeField]
    private float noteSpeed = 1.0f;


    [Header("��ʾЧ��")]
    [Space]
    [SerializeField]
    [Tooltip("�Ƿ���")]
    private bool isFeadOut = false;
    [Space]
    [Tooltip("������")]
    [SerializeField]
    private float transLineIn =2.0f;
   
    [Tooltip("������")]
    [SerializeField]
    private float transLineOut = 0.86f;
  
    [Tooltip("���������ٶ�")]
    [SerializeField]
    private float transInSpeed = 50.0f;

    [Tooltip("���������ٶ�")]
    [SerializeField]
    private float transOutSpeed = 70.0f;
   
    //[Header("�������")]

    //[Tooltip("�����������ܵ÷�")]
    //[SerializeField]
    //private float perfectBeatScore = 10.0f;
   
    //[Tooltip("������ͨ���ܵ÷�")]
    //[SerializeField]
    //private float normalBeatScore = 5.0f;
   
    //[Tooltip("����ʧ�ܿ۳�Ѫ��")]
    //[SerializeField]
    //private float cutHealth = 10.0f;
    
    //[Tooltip("�����������ĵ÷�")]
    //[SerializeField]
    //private float perfectSwordHeartScore = 10.0f;
   
    //[Tooltip("������ͨ���ĵ÷�")]
    //[SerializeField]
    //private float normalSwordHeartScore = 5.0f;

    //[Tooltip("��ħ����ֵ")]
    //[SerializeField]
    //private float heartDemoScore =10.0f;
    /// <summary>
    /// ����λ��
    /// </summary>
    public NotePostion NoteInsPostion { get => noteInsPostion; set => noteInsPostion = value; }
    /// <summary>
    /// ��������
    /// </summary>
    public NoteManger.NoteType NoteType { get => noteType; set => noteType = value; }
    /// <summary>
    /// ��ʼ����ģ�Ͱ뾶�����ж��뾶��
    /// </summary>
    public float NoteWithShinkSpeed { get => noteWithShinkSpeed; set => noteWithShinkSpeed = value; }
    /// <summary>
    /// �����ٶ�
    /// </summary>
    public float NoteSpeed { get => noteSpeed; set => noteSpeed = value; }
    /// <summary>
    /// �������뵭���ٶ�
    /// </summary>
    public float TransInSpeed { get => transInSpeed; set => transInSpeed = value; }
    /// <summary>
    /// ���������ٶ�
    /// </summary>
    public float TransOutSpeed { get => transOutSpeed; set => transOutSpeed = value; }
    /// <summary>
    /// �����������ܵ÷�
    /// </summary>
    //public float PerfectBeatScore { get => perfectBeatScore; set => perfectBeatScore = value; }
    ///// <summary>
    ///// ������ͨ���ܵ÷�
    ///// </summary>
    //public float NormalBeatScore { get => normalBeatScore; set => normalBeatScore = value; }
    ///// <summary>
    ///// ����ʧ�ܿ۳�Ѫ��
    ///// </summary>
    //public float CutHealth { get => cutHealth; set => cutHealth = value; }
    ///// <summary>
    ///// �����������ĵ÷�
    ///// </summary>
    //public float PerfectSwordHeartScore { get => perfectSwordHeartScore; set => perfectSwordHeartScore = value; }
    ///// <summary>
    ///// ������ͨ���ĵ÷�
    ///// </summary>
    //public float NormalSwordHeartScore { get => normalSwordHeartScore; set => normalSwordHeartScore = value; }
    ///// <summary>
    ///// ��ħ��������
    ///// </summary>
    //public float HeartDemoScore { get => heartDemoScore; set => heartDemoScore = value; }
    /// <summary>
    /// ��Ч����
    /// </summary>
    public NoteManger.SFX_Type SfxType { get => sfxType; set => sfxType = value; }
    /// <summary>
    /// ���뿪ʼ��
    /// </summary>
    public float TransLineIn { get => transLineIn; set => transLineIn = value; }
    /// <summary>
    /// ������ʼ��
    /// </summary>
    public float TransLineOut { get => transLineOut; set => transLineOut = value; }
    /// <summary>
    /// �Ƿ�������Ч��
    /// </summary>
    public bool IsFeadOut { get => isFeadOut; set => isFeadOut = value; }
    /// <summary>
    /// ��������
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
