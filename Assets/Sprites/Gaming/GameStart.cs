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
    public GameObject GameEnd;
    public Text markedWords;
    private int startTime=3;
    public Text startTimeText;
    private bool isGameStart = false;
    public string startVideoName;
    public string endVideoName;
    void Start()
    {
        VideoName.Start = startVideoName;
        VideoName.End = endVideoName;

    }
    private bool startVideo =true;
    private bool endVideo = false;
    // Update is called once per frame
    void Update()
    {
       
        if (startVideo)
        {
            //VideoManager.DisplayFedIn();
            VideoManager.PlayVideo(VideoName.Start);
            startVideo = false;

          
        }
        
        //当视频还剩4s时淡出
        if (VideoManager.Instance.curentTime >= VideoManager.Instance.videoTime - 4&&!endVideo||Input.GetKeyDown(KeyCode.Escape))
        {
            markedWords.gameObject.SetActive(false);
            Debug.LogWarning("当前" + VideoManager.Instance.curentTime);
            VideoManager.DisplayFedOut();
            endVideo = true;
            Invoke("StopVideo", 2);
            Invoke("UIActiveTrue", 1);
          
        }
        CountDown();
    }
    private void  StopVideo()
    {
        VideoManager.StopVideo(VideoName.Start);
    }
    /// <summary>
    /// 倒计时显示与开始游戏
    /// </summary>
    private void CountDown()
    {
        if (startTime < 0)
        {
            startTimeText.gameObject.SetActive(false);
        }
        if (!isGameStart && startTime < 0)
        {
          
            StartGame();
            isGameStart = true;
        }
    }
    /// <summary>
    /// 显示UI
    /// </summary>
    private void UIActiveTrue()
    {
        UI.SetActive(true);
        StartCoroutine(ChangeStartTime());
    }
    /// <summary>
    /// 开始倒计时
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeStartTime()
    {
        while(startTime >=0)
        {
          
            Debug.Log("staritTime" + startTime);
            switch(startTime)
            {
                case 3: startTimeText.text = "叁";
                    break; 
                case 2: startTimeText.text = "贰";
                    break;
                case 1: startTimeText.text = "壹";
                    break;
                case 0: startTimeText.text = "起";
                    break;
            }
            yield return new WaitForSeconds(1);
            startTime--;
        }
       
        
    }
    /// <summary>
    /// 脚本启用
    /// </summary>
    private void StartGame()
    {
        MusicPlayer.SetActive(true);
        notemanager.SetActive(true);
        InputMnagerGameObject.SetActive(true);
        setingPanel.SetActive(true);
        GameEnd.SetActive(true);
    }
}
