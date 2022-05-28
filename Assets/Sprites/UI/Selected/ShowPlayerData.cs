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
            Debug.LogWarning("�浵�б�Ϊ��");
            swordHeartText.text = "���ģ�������";
            scoreText.text      = "�÷֣�������";
            heartDemo.text      = "��ħ��������";
            numOfHits.text      = "������������";
        }
       
          

    }

    // Update is called once per frame
    void Update()
    {

       
        try
        {
            if (saveData != null && saveData.Count >= autoCenterView.curCenterChildIndex)
            {
                swordHeartText.text  = "���ģ�" + saveData[autoCenterView.curCenterChildIndex].swordHeartScore;
                scoreText.text       = "�÷֣�" + saveData[autoCenterView.curCenterChildIndex].playerScore;
                heartDemo.text       = "��ħ��" + saveData[autoCenterView.curCenterChildIndex].heartDemonScore;
                numOfHits.text       = "������" + saveData[autoCenterView.curCenterChildIndex].maxNumOfHits;
            }
            else
            {
                Debug.Log("�޴浵");
            }
        }
        catch (System.Exception e)
        {
            swordHeartText.text = "���ģ�������" ;
            scoreText.text      = "�÷֣�������" ;
            heartDemo.text      = "��ħ��������" ;
            numOfHits.text      = "������������" ;
            Debug.LogWarning("�浵Ϊ��");
        }

       
        
    }
}

