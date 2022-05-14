using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [System.Serializable]
   public class videoItem
    {
        [Header("视频剪辑")]
        public VideoClip videoClip;
        [Header("播放器")]
        public VideoPlayer videoPlayer;
    }
    [Header("视频管理")]
    public List<videoItem> videoItems=new List<videoItem>();
    private Dictionary<string, videoItem> _videoDic= new Dictionary<string, videoItem>();

    public static  VideoManager Instance { get; set; }

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
                Debug.LogError("视频剪辑为空");
            }
            _videoDic.Add(item.videoClip.name, item);
            Debug.Log(_videoDic.ToString());
        }

    }
    /// <summary>
    /// 播放视频
    /// </summary>
    /// <param name="name">视频名字</param>
    
    public static void PlayVideo(string name)
    {
        if (!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("该视频不存在");
            return;
        }
        Instance._videoDic[name].videoPlayer.clip = Instance._videoDic[name].videoClip;
        Instance._videoDic[name].videoPlayer.Play();
    }
    /// <summary>
    /// 屏幕淡出
    /// </summary>
    public static void DisplayFedOut()
    {
      
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedOut");
       
    }
    /// <summary>
    /// 屏幕淡入
    /// </summary>
    public static void DisplayFedIn()
    {
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedIn");
    }
   
    public static void StopVideo (string name)
    {
        if (!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("该视频不存在");
            return;
        }
        Instance._videoDic[name].videoPlayer.Stop();
    }
    public static bool VideoIsPlaying(string name)
    {
        if(!Instance._videoDic.ContainsKey(name))
        {
            Debug.LogWarning("该视频不存在");
            return false;
        }
       return Instance._videoDic[name].videoPlayer.isPlaying;
    }
    public static bool VideoIsPaused(string name)
    {
        return Instance._videoDic[name].videoPlayer.isPaused;
    }
}
