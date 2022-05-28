using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Slider HP_slider;
    public Slider SwordHeart_Slider;
    public Image DemoMask_Image;
    public Text PlayerScore_Text;
    public GameObject leaves;
    public GameObject potal;
    public GameObject lotus;
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

    public float SwordTime = 10.0f;
    [Header("��ħֵ")]
    [SerializeField]
    private float heartDemonScore;
  
    [Header("��ǰ��ħֵ")]
    [SerializeField]
    private float curentHeartDemonSCore;

    [Header("������")]
    [SerializeField]
    private int numOfHits;
    [Header("������Ҷ��������")]
    public int numToLeaves;
    [Header("���ֻ����������")]
    public int numToPetal;
    [Header("���ֺɻ���������")]
    public int numOflotus;

    [Header("��ҵ÷�")]
    [SerializeField]
    private float playerScore;
    
    private Transform UIScoreTrans;


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

    public int maxNumOdHits = 0;

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
        PlayerScoreUpdate();

    }
    private void PlayerScoreUpdate()
    {
        PlayerScore_Text.text = "�÷֣�" + playerScore;
    }

    /// <summary>
    /// �����������ֵ
    /// </summary>
    private void PlayerHealthUpdate()
    {
        Debug.Log("currentSword" + curentSwordHeartScore);
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
    /// ���½���ֵ��
    /// </summary>
    private void SwordHeartScoreUpdate()
    {
        Animator SH_Anim = SwordHeart_Slider.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        //TODO:���½���ֵ
       SwordHeart_Slider.value = CurentSwordHeartScore / SwordHeartScore;
        if(curentSwordHeartScore >= swordHeartScore)
        {
           
            SH_Anim.SetBool("ScabbardFalled", true);
            SH_Anim.SetBool("ScabbardBackToIdel", false);
            SH_Anim.SetBool("ScabbardBack", false);
            //-1�Ǽ�ȥ����ʱ��
            if (SHToZero)
            {
                Invoke("SwordHeartToZero", SwordTime - 1);
                SHToZero = false;
            }
          
        }
        if(curentSwordHeartScore<SwordHeartScore)
        {
           
            SH_Anim.SetBool("ScabbardBack",true);
            SH_Anim.SetBool("ScabbardBackToIdel", true);
            SH_Anim.SetBool("ScabbardFalled", false);

        }
        
    }
    private bool SHToZero = true;
    public void SwordHeartToZero()
    {
        
            curentSwordHeartScore = 0.9f * SwordHeartScore;
            SHToZero = true;  
    }
 
    /// <summary>
    /// ������ħֵ
    /// </summary>
    private void HeartDemonScoreUpdate()
    {
        Animator demoAnim = DemoMask_Image.transform.GetChild(1).GetComponent<Animator>(); 
        //TODO:������ħֵ
        if (3*CurentHeartDemonSCore>=2*heartDemonScore &&  CurentHeartDemonSCore <heartDemonScore)
        {
            Debug.Log("����");
            demoAnim.SetBool("HalfHiddenEyes", true);
            demoAnim.SetBool("OpeanEyes", false);
        }
        else if( CurentHeartDemonSCore >=  heartDemonScore)
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
    /// ������������Ӧ״̬
    /// </summary>
    private void NumOfHitsUpdate()
    {
        float speed = 0.01f;

        Camera MainCam = this.gameObject.GetComponent<Canvas>().worldCamera;
        if (maxNumOdHits < NumOfHits)
        {
            maxNumOdHits = NumOfHits;
        }
        
        if (NumOfHits >=2 &&NumOfHits>curentNumOfhits)
        {
            float H, S, V = 0;
            Color.RGBToHSV(MainCam.backgroundColor, out H, out S, out V);
            
            curentNumOfhits = numOfHits;
           // Debug.Log(Mathf.Clamp(V + NumOfHits * speed, 0.0f, 0.69f));
           MainCam.backgroundColor = Color.HSVToRGB(0.0f, 0.0f, Mathf.Clamp(V + speed, 0.0f, 0.69f)); 
        }
        if(NumOfHits >=numToLeaves)
        {
            leaves.SetActive(true);
        }
        if(NumOfHits >= numToPetal)
        {
            potal.SetActive(true);
        }
        if(NumOfHits >= numOflotus)
        {
            lotus.SetActive(true);
        }
    }


}
