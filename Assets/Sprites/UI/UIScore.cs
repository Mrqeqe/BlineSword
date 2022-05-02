using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Slider HP_slider;
    public Slider SwordHeart_Slider;
    public Image DemoMask_Image;
    public GameObject SwordFire;
    [Header("UI��ĸ��ֵ�������д����κ���ֵ��������ʾ����")]
    [SerializeField]
    private float maxUILength;

    [Header("���Ѫ��")]
    [SerializeField]
    private float playerHealth;

    [Header("��ǰ���Ѫ��")]
    [SerializeField]
    private float curentPlayerHealth;
   
    [Header("����ֵ")]
    [SerializeField]
    private float swordHeartScore;
   
    [Header("��ǰ����ֵ")]
    [SerializeField]
    private float curentSwordHeartScore;
   
    [Header("��ħֵ")]
    [SerializeField]
    private float heartDemonScore;
  
    [Header("��ǰ��ħֵ")]
    [SerializeField]
    private float curentHeartDemonSCore;

    [Header("������")]
    [SerializeField]
    private int numOfHits;

    [Header("��ҵ÷�")]
    [SerializeField]
    private float playerScore;
    
    private Transform UIScoreTrans;
    /// <summary>
    /// UI��ĸ�����ڼ�����ʾ����
    /// </summary>
    private float MaxUILength { get => maxUILength; set => maxUILength = value; }

    /// <summary>
    /// ���Ѫ��
    /// </summary>
    public float PlayerHealth { get => playerHealth; set => playerHealth = value; }
    /// <summary>
    /// ��ǰ���Ѫ��
    /// </summary>
    public float CurentPlayerHealth { get => curentPlayerHealth; set => curentPlayerHealth = value; }
    /// <summary>
    /// ����ֵ
    /// </summary>
    public float SwordHeartScore { get => swordHeartScore; set => swordHeartScore = value; }
    /// <summary>
    ///  ��ǰ����ֵ
    /// 
    /// </summary>
    public float CurentSwordHeartScore { get => curentSwordHeartScore; set => curentSwordHeartScore = value; }
    /// <summary>
    /// ��ħֵ
    /// </summary>
    public float HeartDemonScore { get => heartDemonScore; set => heartDemonScore = value; }
    /// <summary>
    /// ��ǰ��ħֵ
    /// </summary>
    public float CurentHeartDemonSCore { get => curentHeartDemonSCore; set => curentHeartDemonSCore = value; }
    /// <summary>
    /// ������
    /// </summary>
    public int NumOfHits { get => numOfHits; set => numOfHits = value; }
    /// <summary>
    /// ��ҵ÷�
    /// </summary>
    public float PlayerScore { get => playerScore; set => playerScore = value; }


    private void Start()
    {
        UIScoreTrans = GetComponent<Transform>();
        CurentPlayerHealth = PlayerHealth;
        InitializedUI();
    }
    private void Update()
    {
     
        UpdateUI();
    }
    /// <summary>
    /// ��ʼ��UI
    /// </summary>
    private void InitializedUI()
    {
        HP_slider.maxValue = playerHealth;
        HP_slider.minValue = 0.0f;
        SwordHeart_Slider.maxValue = 1.0f ;
        SwordHeart_Slider.minValue = 0.0f;

    }

    /// <summary>
    /// ˢ������UI
    /// </summary>
    private void UpdateUI()
    {
     
        PlayerHealthUpdate();
        SwordHeartScoreUpdate();
        HeartDemonScoreUpdate();
        NumOfHitsUpdate();


    }
    private void PlayerScoreUpdate()
    {
        UIScoreTrans.GetChild(0).GetChild(4).GetComponent<Text>().text = "�÷֣�" + playerScore;
    }

    /// <summary>
    /// �����������ֵ
    /// </summary>
    private void PlayerHealthUpdate()
    {
        Animator hpAnim = HP_slider.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        //TODO�������������ֵ
       HP_slider.value = CurentPlayerHealth;
       
        if(10*curentPlayerHealth <=4*playerHealth && 10 *curentPlayerHealth >= playerHealth)
        { 
            hpAnim.SetBool("FireMinToGrew", true);
            hpAnim.SetBool("FireGrewToMax", true);
            hpAnim.SetBool("FireMaxToDown", false);
        }
      else if(10 * curentPlayerHealth < playerHealth )
        {
            hpAnim.SetBool("FireMaxToDown", true);
            hpAnim.SetBool("FireDownToMin", true);
            hpAnim.SetBool("FireMinToGrew", false);
            hpAnim.SetBool("FireGrewToMax", false);
        }
    }
    /// <summary>
    /// ���ƽ�����������
    /// </summary>

    /// <summary>
    /// ���½���ֵ��
    /// </summary>
    private void SwordHeartScoreUpdate()
    {
        Animator SH_Anim = SwordHeart_Slider.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        //TODO:���½���ֵ
       SwordHeart_Slider.value = CurentSwordHeartScore / SwordHeartScore;
        if(curentSwordHeartScore >= swordHeartScore)
        {
            SwordFire.gameObject.SetActive(true);
            SH_Anim.SetBool("ScabbardFalled", true);
            SH_Anim.SetBool("ScabbardBackToIdel", false);
            SH_Anim.SetBool("ScabbardBack", false);
        }
        if(curentSwordHeartScore<SwordHeartScore)
        {
            SwordFire.gameObject.SetActive(false);
            SH_Anim.SetBool("ScabbardBack",true);
            SH_Anim.SetBool("ScabbardBackToIdel", true);
            SH_Anim.SetBool("ScabbardFalled", false);

        }
        
    }
    /// <summary>
    /// ������ħֵ
    /// </summary>
    private void HeartDemonScoreUpdate()
    {
        Animator demoAnim = DemoMask_Image.transform.GetChild(1).GetComponent<Animator>(); 
        //TODO:������ħֵ
        if (3*CurentHeartDemonSCore>heartDemonScore && 3 * CurentHeartDemonSCore <2*heartDemonScore)
        {
            demoAnim.SetBool("HalfHiddenEyes", true);
            demoAnim.SetBool("OpeanEyes", false);
        }
        else if(3 * CurentHeartDemonSCore > 2 * heartDemonScore)
        {
            demoAnim.SetBool("OpeanEyes", true);
            demoAnim.SetBool("HalfHiddenEyes", false);
        }
        else
        {
            demoAnim.SetBool("HalfHiddenEyes", false);
        }
        
    }
    private int curentNumOfhits = 0;
 
    /// <summary>
    /// ����������
    /// </summary>
    private void NumOfHitsUpdate()
    {
        float speed = 0.01f;

        Camera MainCam = this.gameObject.GetComponent<Canvas>().worldCamera;

        
        if (NumOfHits >=2 &&NumOfHits>curentNumOfhits)
        {
            float H, S, V = 0;
            Color.RGBToHSV(MainCam.backgroundColor, out H, out S, out V);
            
            curentNumOfhits = numOfHits;
            Debug.Log(Mathf.Clamp(V + NumOfHits * speed, 0.0f, 0.69f));
           
                MainCam.backgroundColor = Color.HSVToRGB(0.0f, 0.0f, Mathf.Clamp(V + speed, 0.0f, 0.69f));
            
            
        }
      
      


    }


}
