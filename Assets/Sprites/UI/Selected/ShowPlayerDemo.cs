using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerDemo : MonoBehaviour
{
 
    public  Text HeDeText;
    private List<SaveData> saveData;
    void Start()
    {
        if(saveData !=null)
        {
            saveData = PlayerData.Instance.LoadFromJson().dataList;
        }
      
    }


    void Update()
    {
        if(saveData !=null)
        {
            float demoScore = 0;
            foreach (var item in saveData)
            {
                demoScore += item.heartDemonScore;
            }
            HeDeText.text = "ÐÄÄ§Öµ£º" +demoScore;
        }
    }
}
