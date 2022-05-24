using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerData : MonoBehaviour
{
 
    public  Text HeDeText;
    private SaveData saveData;
    void Start()
    {
        saveData = PlayerData.Instance.LoadFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        if(saveData !=null)
        {
            HeDeText.text = "ÐÄÄ§Öµ£º" + saveData.heartDemonScore;
        }
    }
}
