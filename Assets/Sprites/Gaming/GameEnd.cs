using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public AudioSource KereAudioSource;
    public GameObject UI;
    public GameObject DeathImage;
    
    private double audioTime = 99999.0;
    private double currentTime = 0.0;
    public  double reduceVolue = 3;
    private bool isDead = false;
    void Start()
    {
        audioTime = KereAudioSource.clip.length;
        Debug.Log(audioTime + "����");
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
            playEndVideo = false;
        }
        if (VideoManager.Instance.curentTime >= VideoManager.Instance.videoTime - 4 && !StopEndVideo || Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerData.Instance.SaveByJson();//�浵
            Debug.LogWarning("��ǰ" + VideoManager.Instance.curentTime);
            VideoManager.DisplayFedOut();
            StopEndVideo = true;
            Invoke("StopVideo", 2);
            Invoke("UIActiveTrue", 1);
            ReturnMain();
        }

        IsDeath();
      
    }
    private void IsDeath()
    {
        if(ScoringManager.Instance.UIScore.CurentPlayerHealth <=0)
        {
            KereAudioSource.Pause();
            DeathImage.SetActive(true);
            Debug.Log("��");
            isDead = true;
            PlayerData.Instance.SaveByJson();//�浵
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ReturnMain();
            }
        }
    }
    private void ReturnMain()
    {
        
            Debug.Log("��ת������");
            ReturnMainSence.ReturnMainSenceLoad();
        
    }
}
