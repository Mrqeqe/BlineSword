using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerData : MonoBehaviour
{
    private List<SaveData> saveData;
    public AutoCenterView autoCenterView;
    void Start()
    {
        if (saveData != null)
        {
            saveData = PlayerData.Instance.LoadFromJson().dataList;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (saveData != null)
        {
            Text heartSwordText = this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>();
            Text scoreText = this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<Text>();
            Text heartDemo = this.gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>();
            heartSwordText.text = "剑心：" + saveData[autoCenterView.curCenterChildIndex].heartDemonScore;
            scoreText.text = "得分：" + saveData[autoCenterView.curCenterChildIndex].playerScore;
            heartDemo.text = "心魔：" + saveData[autoCenterView.curCenterChildIndex].heartDemonScore;
        }
        
    }
}

