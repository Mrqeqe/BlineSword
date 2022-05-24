using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public AudioSource KereAudioSource;
    public GameObject UI;
    public GameObject DeathImage;
    public GameObject ScorePanel;
    public GameObject markedWords;
    public GameObject SetingPanel;

    private double audioTime = 99999.0;
    private double currentTime = 0.0;
    public  double reduceVolue = 3;
    private bool isDead = false;
    private bool showScorePanel = false;
    void Start()
    {
        audioTime = KereAudioSource.clip.length;
        Debug.Log(audioTime + "长度");
    }

    private bool playEndVideo = true;
    private bool StopEndVideo = false;
    void Update()
    {
        currentTime = KereAudioSource.time;
        if (currentTime >= audioTime - reduceVolue && playEndVideo)
        {
            UI.SetActive(false);
            VideoManager.DisplayFedIn();
            VideoManager.PlayVideo(VideoName.End);
            markedWords.SetActive(true);
            SetingPanel.SetActive(false);
            playEndVideo = false;
        }
        if ( Input.GetKeyDown(KeyCode.Escape)&&VideoManager.Instance.curentTime>0|| VideoManager.Instance.curentTime >= VideoManager.Instance.videoTime - 4 && !StopEndVideo)
        {
            PlayerData.Instance.SaveByJson();//存档
            Debug.LogWarning("当前" + VideoManager.Instance.curentTime);
            VideoManager.DisplayFedOut();
            StopEndVideo = true;
            Invoke("StopVideo", 2);
            Invoke("UIActiveTrue", 1);
            ShowScorePanel();
            showScorePanel = true;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& showScorePanel)
        {
            ReturnMain();
            showScorePanel = false;
        }
        IsDeath();
      
    }
    private void IsDeath()
    {
        if(ScoringManager.Instance.UIScore.CurentPlayerHealth <=0)
        {
            KereAudioSource.Pause();
            DeathImage.SetActive(true);
            Debug.Log("死");
            isDead = true;
            PlayerData.Instance.SaveByJson();//存档
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ReturnMain();
            }
        }
    }
    private void ReturnMain()
    {
        
            Debug.Log("跳转主场景");
            ReturnMainSence.ReturnMainSenceLoad();
        
    }
    private void ShowScorePanel()
    {
        ScorePanel.SetActive(true);
        Text heartSwordText = ScorePanel.transform.GetChild(1).GetChild(1).GetComponent<Text>();
        Text scoreText = ScorePanel.transform.GetChild(2).GetChild(1).GetComponent<Text>();
        Text heartDemo = ScorePanel.transform.GetChild(3).GetChild(1).GetComponent<Text>();
        heartSwordText.text = "剑心：" + ScoringManager.Instance.UIScore.CurentSwordHeartScore;
        scoreText.text = "得分：" + ScoringManager.Instance.UIScore.PlayerScore;
        heartDemo.text = "心魔：" + ScoringManager.Instance.UIScore.CurentHeartDemonSCore;
    }
}
