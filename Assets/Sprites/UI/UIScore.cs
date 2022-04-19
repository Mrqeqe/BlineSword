using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
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
        RectTransform HealthTrans = UIScoreTrans.GetChild(0).GetChild(1).GetComponent<RectTransform>();
        HealthTrans.sizeDelta = new Vector2(HealthTrans.sizeDelta.x *(PlayerHealth/MaxUILength), HealthTrans.sizeDelta.y);

        RectTransform SwordheartscoreTrans = UIScoreTrans.GetChild(0).GetChild(2).GetComponent<RectTransform>();
        SwordheartscoreTrans.sizeDelta = new Vector2(HealthTrans.sizeDelta.x * (PlayerHealth / MaxUILength), HealthTrans.sizeDelta.y);
    
        RectTransform HeartDemonScore = UIScoreTrans.GetChild(0).GetChild(3).GetComponent<RectTransform>();
        HeartDemonScore.sizeDelta = new Vector2(HealthTrans.sizeDelta.x * (PlayerHealth / MaxUILength), HealthTrans.sizeDelta.y);
    
    }

    /// <summary>
    /// ˢ������UI
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
        UIScoreTrans.GetChild(0).GetChild(4).GetComponent<Text>().text = "�÷֣�" + playerScore;
    }
    /// <summary>
    /// �����������ֵ
    /// </summary>
    private void PlayerHealthUpdate()
    {
        //TODO�������������ֵ
        UIScoreTrans.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = CurentPlayerHealth/PlayerHealth;
      
        
    }
    /// <summary>
    /// ���½���ֵ��
    /// </summary>
    private void SwordHeartScoreUpdate()
    {
        //TODO:���½���ֵ
        UIScoreTrans.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().fillAmount = CurentSwordHeartScore / SwordHeartScore;
        
    }
    /// <summary>
    /// ������ħֵ
    /// </summary>
    private void HeartDemonScoreUpdate()
    {
        //TODO:������ħֵ
        UIScoreTrans.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>().fillAmount = CurentHeartDemonSCore / HeartDemonScore;
        
    }
    /// <summary>
    /// ����������
    /// </summary>
    private void NumOfHitsUpdate()
    {   
        if(NumOfHits >0)
        {
            UIScoreTrans.GetChild(0).GetChild(0).gameObject.SetActive(true);
            UIScoreTrans.GetChild(0).GetChild(0).GetComponent<Text>().text = "��������" + NumOfHits;
        }
        else
        {
            UIScoreTrans.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        
    }


}
