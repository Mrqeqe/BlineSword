using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// 音频管理器，存储所有音频并且可以播放和暂停
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// 存储单个音频的信息
    /// </summary>
    /// 
    [System.Serializable]
   public class Sound
    {
        [Header("音频剪辑")]
        public AudioClip clip;

        [Header("音频分组")]
        public AudioMixerGroup outputGroup;

        [Header("音频音量")]
        [Range(0, 1)]
        public float volume = 1;
        
        [Header("左右声道")]
        [Range(-1,1)]
        public float steroPan = 0;
        
        [Header("音频是否开局播放")]
        public bool playOnAwake = false;

        [Header ("音频是否循环播放")]
        public bool loop = false;
    }
    /// <summary>
    /// 存储所有的音频信息
    /// </summary>
    public List<Sound> sounds;
    /// <summary>
    /// 每一个音频名称对应一个音频组件
    /// </summary>
    private Dictionary<string, AudioSource> audiosDic;
    /// <summary>
    /// 单例
    /// </summary>
    private static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audiosDic = new Dictionary<string, AudioSource>();
        }
 
    }
    private void Start()
    {
        foreach (var sound in sounds)
        {
           if(sound.clip == null)
            {
                Debug.LogError("列表音频剪辑未赋值");
            }
            GameObject obj = new GameObject(sound.clip.name);
            obj.transform.SetParent(transform);

            AudioSource source = obj.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.playOnAwake = sound.playOnAwake;
            source.loop = sound.loop;
            source.volume = sound.volume;
            source.panStereo = sound.steroPan;
            source.outputAudioMixerGroup = sound.outputGroup;
            if(sound.playOnAwake)
            {
                source.Play();
            }
            audiosDic.Add(sound.clip.name, source);
        }
    }
    /// <summary>
    /// 播放某一个音频
    /// </summary>
    /// <param name="name">音频名称</param>
    /// <param name="isWait">是否等待音频播放完</param>
    public static void PlayAudio(string name ,bool isWait = false)
    {
        if(!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"名为{name}音频不存在");
            return;
        }
        if(isWait)
        {
            if(!instance.audiosDic[name].isPlaying)
            {
                instance.audiosDic[name].Play();
            }
        }
        else
        {
            instance.audiosDic[name].Play();
        }
    }
    /// <summary>
    /// 停止某一音频的播放
    /// </summary>
    /// <param name="name">音频名字</param>
    public static  void StopAudio(string name)
    {
        if (!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"名为{name}音频不存在");
            return;
        }
        instance.audiosDic[name].Stop();
        
    }
    /// <summary>
    /// 获取音频源
    /// </summary>
    /// <param name="name">音频名称</param>
    /// <returns></returns>
    public static AudioSource GetAudioSoure(string name)
    {
        if(!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"名为{name}音频不存在");
            return null;
        }
        else
        {
            return instance.audiosDic[name];
        }
    }
}
