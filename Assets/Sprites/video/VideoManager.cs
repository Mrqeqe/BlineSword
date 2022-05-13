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
           
        }
        Instance._videoDic[name].videoPlayer.clip = Instance._videoDic[name].videoClip;
        Instance._videoDic[name].videoPlayer.Play();
    }
    public static void DisplayFedOut()
    {
      
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedOut");
       
    }
    public static void DisplayFedIn()
    {
        Instance.gameObject.GetComponent<Animator>().SetTrigger("FedIn");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            VideoManager.PlayVideo("start");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayFedOut();
        }
    }
}
