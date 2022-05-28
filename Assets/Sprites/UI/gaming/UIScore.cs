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
    [Header("玩家血量")]
    [SerializeField]
    private float playerHealth;

    [Header("当前玩家血量")]
    [SerializeField]
    private float curentPlayerHealth;
   
    [Header("剑心值")]
    [SerializeField]
    private float swordHeartScore;
   
    [Header("当前剑心值")]
    [SerializeField]
    private float curentSwordHeartScore;

    public float SwordTime = 10.0f;
    [Header("心魔值")]
    [SerializeField]
    private float heartDemonScore;
  
    [Header("当前心魔值")]
    [SerializeField]
    private float curentHeartDemonSCore;

    [Header("连击数")]
    [SerializeField]
    private int numOfHits;
    [Header("出现竹叶的连击数")]
    public int numToLeaves;
    [Header("出现花瓣的连击数")]
    public int numToPetal;
    [Header("出现荷花的连击数")]
    public int numOflotus;

    [Header("玩家得分")]
    [SerializeField]
    private float playerScore;
    
    private Transform UIScoreTrans;


    /// <summary>
    /// 玩家血量
    /// </summary>
    public float PlayerHealth { get => playerHealth; set => playerHealth = value; }
    /// <summary>
    /// 当前玩家血量
    /// </summary>
    public float CurentPlayerHealth { get => curentPlayerHealth; set => curentPlayerHealth = value; }
    /// <summary>
    /// 剑心值
    /// </summary>
    public float SwordHeartScore { get => swordHeartScore; set => swordHeartScore = value; }
    /// <summary>
    ///  当前剑心值
    /// 
    /// </summary>
    public float CurentSwordHeartScore { get => curentSwordHeartScore; set => curentSwordHeartScore = value; }
    /// <summary>
    /// 心魔值
    /// </summary>
    public float HeartDemonScore { get => heartDemonScore; set => heartDemonScore = value; }
    /// <summary>
    /// 当前心魔值
    /// </summary>
    public float CurentHeartDemonSCore { get => curentHeartDemonSCore; set => curentHeartDemonSCore = value; }
    /// <summary>
    /// 连击数
    /// </summary>
    public int NumOfHits { get => numOfHits; set => numOfHits = value; }
    /// <summary>
    /// 玩家得分
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
    /// 初始化UI
    /// </summary>
    private void InitializedUI()
    {
        HP_slider.maxValue = playerHealth;
        HP_slider.minValue = 0.0f;
        SwordHeart_Slider.maxValue = 1.0f ;
        SwordHeart_Slider.minValue = 0.0f;

    }

    /// <summary>
    /// 刷新所有UI
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
        PlayerScore_Text.text = "得分：" + playerScore;
    }

    /// <summary>
    /// 更新玩家生命值
    /// </summary>
    private void PlayerHealthUpdate()
    {
        Debug.Log("currentSword" + curentSwordHeartScore);
        Animator hpAnim = HP_slider.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        //TODO：更新玩家生命值
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
    /// 更新剑心值，
    /// </summary>
    private void SwordHeartScoreUpdate()
    {
        Animator SH_Anim = SwordHeart_Slider.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        //TODO:更新剑心值
       SwordHeart_Slider.value = CurentSwordHeartScore / SwordHeartScore;
        if(curentSwordHeartScore >= swordHeartScore)
        {
           
            SH_Anim.SetBool("ScabbardFalled", true);
            SH_Anim.SetBool("ScabbardBackToIdel", false);
            SH_Anim.SetBool("ScabbardBack", false);
            //-1是减去动画时间
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
    /// 更新心魔值
    /// </summary>
    private void HeartDemonScoreUpdate()
    {
        Animator demoAnim = DemoMask_Image.transform.GetChild(1).GetComponent<Animator>(); 
        //TODO:更新心魔值
        if (3*CurentHeartDemonSCore>=2*heartDemonScore &&  CurentHeartDemonSCore <heartDemonScore)
        {
            Debug.Log("半眼");
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
    /// 更新连击数反应状态
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
