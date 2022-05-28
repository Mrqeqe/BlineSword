using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerData : MonoBehaviour
{
    private List<SaveData> saveData ;
    public AutoCenterView autoCenterView;
    Text swordHeartText ;
    Text scoreText      ;
    Text heartDemo      ;
    Text numOfHits      ;
    void Start()
    {
         swordHeartText = this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>();
         scoreText      = this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<Text>();
         heartDemo      = this.gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>();
         numOfHits      = this.gameObject.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        try
        {
            saveData = PlayerData.Instance.LoadFromJson().dataList;
        }
        catch(System.Exception e)
        {
            Debug.LogWarning("存档列表为空");
            swordHeartText.text = "剑心：无数据";
            scoreText.text      = "得分：无数据";
            heartDemo.text      = "心魔：无数据";
            numOfHits.text      = "连击：无数据";
        }
       
          

    }

    // Update is called once per frame
    void Update()
    {

       
        try
        {
            if (saveData != null && saveData.Count >= autoCenterView.curCenterChildIndex)
            {
                swordHeartText.text  = "剑心：" + saveData[autoCenterView.curCenterChildIndex].swordHeartScore;
                scoreText.text       = "得分：" + saveData[autoCenterView.curCenterChildIndex].playerScore;
                heartDemo.text       = "心魔：" + saveData[autoCenterView.curCenterChildIndex].heartDemonScore;
                numOfHits.text       = "连击：" + saveData[autoCenterView.curCenterChildIndex].maxNumOfHits;
            }
            else
            {
                Debug.Log("无存档");
            }
        }
        catch (System.Exception e)
        {
            swordHeartText.text = "剑心：无数据" ;
            scoreText.text      = "得分：无数据" ;
            heartDemo.text      = "心魔：无数据" ;
            numOfHits.text      = "连击：无数据" ;
            Debug.LogWarning("存档为空");
        }

       
        
    }
}

