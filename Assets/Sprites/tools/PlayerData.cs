using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SaveTools;
public class PlayerData : MonoBehaviour
{ 
    /// <summary>
    /// 场景编号
    /// </summary>
    public int SenceNunber;
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
   const string PLAYER_DATA_FILE_NAME = "PlayerData";

    private DataList SavingData()
    {
        var saveData = new SaveData();
      

            saveData.heartDemonScore     = ScoringManager.Instance.UIScore.CurentHeartDemonSCore;
            saveData.playerHealth        = ScoringManager.Instance.UIScore.CurentPlayerHealth;
            saveData.swordHeartScore     = ScoringManager.Instance.UIScore.CurentSwordHeartScore;
            saveData.numOfHits           = ScoringManager.Instance.UIScore.NumOfHits;
            saveData.playerScore         = ScoringManager.Instance.UIScore.PlayerScore;
        

        DataList  datalist= LoadFromJson();
        if(datalist == null)
        {
            Debug.Log("存储列表为空");
            datalist = new DataList();
            for (int i = 0; i < SenceNunber; i++)
            {
                datalist.dataList.Add(new SaveData());
            }
            datalist.dataList.Add(saveData);

        }
        else if (datalist.dataList.Count-1<SenceNunber )
        {
            Debug.Log("存储列表长度不足");
            for (int i = datalist.dataList.Count - 1; i < SenceNunber-1; i++)
            {
                datalist.dataList.Add(new SaveData());
            }
            datalist.dataList.Add ( saveData);
            Debug.Log(datalist.dataList[0].ToString());
        }
        else
        {
            Debug.Log("覆盖数据");
            datalist.dataList[SenceNunber] = saveData;
        }
       
        return datalist;
    }
    
    public  void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }
    public DataList LoadFromJson()
    {
       var saveData= SaveSystem.LoadFromJson<DataList>(PLAYER_DATA_FILE_NAME);

        return saveData;
    }
    [MenuItem("CustomerTools/delet Player Data")]
    public static void  DeletData()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
}   
   
public class DataList
{
    
    [SerializeField]public  List<SaveData> dataList = new List<SaveData>();
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