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

       

    }
    private bool startVideo =true;

    // Update is called once per frame
    void Update()
    {
       
        if (startVideo)
        {
            VideoManager.DisplayFedIn();
            VideoManager.PlayVideo(VideoName.Start);
            startVideo = false;

          
        }
        Debug.Log(VideoManager.VideoIsPlaying(VideoName.Start));
        if(VideoManager.VideoIsPaused(VideoName.Start))
        {

            VideoManager.DisplayFedOut();
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
            Debug.Log("时间到了");
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
            startTimeText.text = startTime + "";
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
    }
}
