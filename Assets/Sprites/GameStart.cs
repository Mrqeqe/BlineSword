using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject notemanager;
    public GameObject MusicPlayer;
    public GameObject UI;
    public GameObject InputMnagerGameObject;
    public GameObject setingPanel;
    private int startTime=3;
    public Text startTimeText;
    private bool isGameStart = false;
    void Start()
    {
        Invoke("UIActiveTrue",1);

    }

    // Update is called once per frame
    void Update()
    {
        if(startTime<0)
        {
            startTimeText.gameObject.SetActive(false);
        }
       if(!isGameStart&&startTime<0)
        {
            StartGame();
            isGameStart = true;
        }
    }

    private void UIActiveTrue()
    {
        UI.SetActive(true);
        StartCoroutine(ChangeStartTime());
       
    }
    IEnumerator ChangeStartTime()
    {
        while(startTime >=0)
        {
          
            Debug.Log("staritTime" + startTime);
            startTimeText.text = startTime + "";
            yield return new WaitForSeconds(1);
            startTime--;
        }
       
        
    }
    private void StartGame()
    {
        MusicPlayer.SetActive(true);
        notemanager.SetActive(true);
        InputMnagerGameObject.SetActive(true);
        setingPanel.SetActive(true);
    }
}
