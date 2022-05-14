using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [System.Serializable]
   public class videoItem
    {
        [Header("��Ƶ����")]
        public VideoClip videoClip;
        [Header("������")]
        public VideoPlayer videoPlayer;
    }
    [Header("��Ƶ����")]
    public List<videoItem> videoItems=new List<videoItem>();
    private Dictionary<string, videoItem> _videoDic= new Dictionary<string, videoItem>();

    public static  VideoManager Instance { get; set; }
    private double _videoTime = 999999999999.0;
    private double _curentTiem=0.0;
    private string _curentVideoName;
    public double videoTime { get { return _videoTime; } }
    public double curentTime { get { return _curentTiem; } }
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        foreach (var item in videoItems)
        {
            if (item.videoClip == null)
            {
                Debug.LogError("��Ƶ����Ϊ��");
            }
            _videoDic.Add(item.videoClip.name, item);
            Debug.Log(_videoDic.ToString());
        }
        
    }
    /// <summary>
    /// ������Ƶ
    /// </summary>
    /// <param name="name">��Ƶ����</param>
    
    public static void PlayVideo(string name)
    {
        if (!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("����Ƶ������");
            return;
        }
        Instance._videoDic[name].videoPlayer.clip = Instance._videoDic[name].videoClip;
        Instance._videoDic[name].videoPlayer.Play();
        
        Instance._videoTime = Instance._videoDic[name].videoPlayer.clip.length;
        Instance._curentVideoName = name;
    }
    /// <summary>
    /// ��Ļ����
    /// </summary>
    public static void DisplayFedOut()
    {
      
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedOut");
       
    }
    /// <summary>
    /// ��Ļ����
    /// </summary>
    public static void DisplayFedIn()
    {
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedIn");
    }
    
    
    public static void StopVideo (string name)
    {
        if (!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("����Ƶ������");
            return;
        }
        Instance._videoDic[name].videoPlayer.Stop();
    }
    public static bool VideoIsPlaying(string name)
    {
        if(!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("����Ƶ������");
            return false;
        }
       return Instance._videoDic[name].videoPlayer.isPlaying;
    }
    public static bool VideoIsPaused(string name)
    { 
        return Instance._videoDic[name].videoPlayer.isPaused;
    }
 
    private void Update()
    {
      
        if(Instance._videoDic.ContainsKey(_curentVideoName))
        {
           // Debug.Log("��Ƶ��ʼ��¼ʱ��");
            _curentTiem = Instance._videoDic[_curentVideoName].videoPlayer.time;
        }
        else
        {
            Debug.LogWarning("û����ƵƬ�Σ�" + Instance._curentVideoName);
        }
    }

   

   
}
