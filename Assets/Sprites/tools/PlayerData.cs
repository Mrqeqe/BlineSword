using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SaveTools;
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; set; }
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public SaveData SavePlayerData
    { get; set; }

    const string PLAYER_DATA_KEY = "PlayerData";
   const string PLAYER_DATA_FILE_NAME = "PlayerData.Mrqe";

    private SaveData SavingData()
    {
        var saveData = new SaveData();
        saveData.heartDemonScore    =      ScoringManager.Instance.UIScore.CurentHeartDemonSCore;
        saveData.playerHealth       =   ScoringManager.Instance.UIScore.CurentPlayerHealth;
        saveData.swordHeartScore     =   ScoringManager.Instance.UIScore.CurentSwordHeartScore;
        saveData.numOfHits          =   ScoringManager.Instance.UIScore.NumOfHits;
        return saveData;
    }
    private void LoadingData(SaveData saveData)
    {

        ScoringManager.Instance.UIScore.CurentHeartDemonSCore = saveData.heartDemonScore;
        ScoringManager.Instance.UIScore.CurentPlayerHealth = saveData.playerHealth;
        ScoringManager.Instance.UIScore.CurentSwordHeartScore = saveData.swordHeartScore;
        ScoringManager.Instance.UIScore.NumOfHits = saveData.numOfHits;
      
    }
    public  void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }
    public  SaveData LoadFromJson()
    {
       var saveData= SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        SavePlayerData = saveData;
        return saveData;
    }
    [MenuItem("CustomerTools/delet Player Data")]
    public static void  DeletData()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
}   
    
[System.Serializable]
public class SaveData
{

    [SerializeField]
    public float playerHealth;

    [Header("剑心值")]
    [SerializeField]
    public float swordHeartScore;


    [Header("心魔值")]
    [SerializeField]
    public float heartDemonScore;

    [Header("连击数")]
    [SerializeField]
    public int numOfHits;

    [Header("玩家得分")]
    [SerializeField]
    public float playerScore;
}