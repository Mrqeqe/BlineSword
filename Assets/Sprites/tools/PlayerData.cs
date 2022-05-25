using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SaveTools;
public class PlayerData : MonoBehaviour
{ 
    /// <summary>
    /// �������
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
            Debug.Log("�洢�б�Ϊ��");
            datalist = new DataList();
            for (int i = 0; i < SenceNunber; i++)
            {
                datalist.dataList.Add(new SaveData());
            }
            datalist.dataList.Add(saveData);

        }
        else if (datalist.dataList.Count-1<SenceNunber )
        {
            Debug.Log("�洢�б��Ȳ���");
            for (int i = datalist.dataList.Count - 1; i < SenceNunber-1; i++)
            {
                datalist.dataList.Add(new SaveData());
            }
            datalist.dataList.Add ( saveData);
            Debug.Log(datalist.dataList[0].ToString());
        }
        else
        {
            Debug.Log("��������");
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

    [Header("����ֵ")]
    [SerializeField]
    public float swordHeartScore;


    [Header("��ħֵ")]
    [SerializeField]
    public float heartDemonScore;

    [Header("������")]
    [SerializeField]
    public int numOfHits;

    [Header("��ҵ÷�")]
    [SerializeField]
    public float playerScore;
}