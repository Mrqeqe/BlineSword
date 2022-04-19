using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [Header("UI分母，值必须下列大于任何数值，计算显示比例")]
    [SerializeField]
    private float maxUILength;

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
   
    [Header("心魔值")]
    [SerializeField]
    private float heartDemonScore;
  
    [Header("当前心魔值")]
    [SerializeField]
    private float curentHeartDemonSCore;

    [Header("连击数")]
    [SerializeField]
    private int numOfHits;

    [Header("玩家得分")]
    [SerializeField]
    private float playerScore;
    
    private Transform UIScoreTrans;
    /// <summary>
    /// UI分母，用于计算显示比例
    /// </summary>
    private float MaxUILength { get => maxUILength; set => maxUILength = value; }

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
        RectTransform HealthTrans = UIScoreTrans.GetChild(0).GetChild(1).GetComponent<RectTransform>();
        HealthTrans.sizeDelta = new Vector2(HealthTrans.sizeDelta.x *(PlayerHealth/MaxUILength), HealthTrans.sizeDelta.y);

        RectTransform SwordheartscoreTrans = UIScoreTrans.GetChild(0).GetChild(2).GetComponent<RectTransform>();
        SwordheartscoreTrans.sizeDelta = new Vector2(HealthTrans.sizeDelta.x * (PlayerHealth / MaxUILength), HealthTrans.sizeDelta.y);
    
        RectTransform HeartDemonScore = UIScoreTrans.GetChild(0).GetChild(3).GetComponent<RectTransform>();
        HeartDemonScore.sizeDelta = new Vector2(HealthTrans.sizeDelta.x * (PlayerHealth / MaxUILength), HealthTrans.sizeDelta.y);
    
    }

    /// <summary>
    /// 刷新所有UI
    /// </summary>
    private void UpdateUI()
    {
        PlayerScoreUpdate();
        PlayerHealthUpdate();
        SwordHeartScoreUpdate();
        HeartDemonScoreUpdate();
        NumOfHitsUpdate();
    }
    private void PlayerScoreUpdate()
    {
        UIScoreTrans.GetChild(0).GetChild(4).GetComponent<Text>().text = "得分：" + playerScore;
    }
    /// <summary>
    /// 更新玩家生命值
    /// </summary>
    private void PlayerHealthUpdate()
    {
        //TODO：更新玩家生命值
        UIScoreTrans.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = CurentPlayerHealth/PlayerHealth;
      
        
    }
    /// <summary>
    /// 更新剑心值，
    /// </summary>
    private void SwordHeartScoreUpdate()
    {
        //TODO:更新剑心值
        UIScoreTrans.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().fillAmount = CurentSwordHeartScore / SwordHeartScore;
        
    }
    /// <summary>
    /// 更新心魔值
    /// </summary>
    private void HeartDemonScoreUpdate()
    {
        //TODO:更新心魔值
        UIScoreTrans.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>().fillAmount = CurentHeartDemonSCore / HeartDemonScore;
        
    }
    /// <summary>
    /// 更新连击数
    /// </summary>
    private void NumOfHitsUpdate()
    {   
        if(NumOfHits >0)
        {
            UIScoreTrans.GetChild(0).GetChild(0).gameObject.SetActive(true);
            UIScoreTrans.GetChild(0).GetChild(0).GetComponent<Text>().text = "连击数：" + NumOfHits;
        }
        else
        {
            UIScoreTrans.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        
    }


}
