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
        try
        {
            saveData = PlayerData.Instance.LoadFromJson().dataList;
        }
        catch(System.Exception e)
        {
            Debug.Log("�޴浵"+e);
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
            HeDeText.text = "��ħֵ��" +demoScore;
        }
    }
}
