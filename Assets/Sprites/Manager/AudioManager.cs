using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// ��Ƶ���������洢������Ƶ���ҿ��Բ��ź���ͣ
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// �洢������Ƶ����Ϣ
    /// </summary>
    /// 
    [System.Serializable]
   public class Sound
    {
        [Header("��Ƶ����")]
        public AudioClip clip;

        [Header("��Ƶ����")]
        public AudioMixerGroup outputGroup;

        [Header("��Ƶ����")]
        [Range(0, 1)]
        public float volume = 1;
        
        [Header("��������")]
        [Range(-1,1)]
        public float steroPan = 0;
        
        [Header("��Ƶ�Ƿ񿪾ֲ���")]
        public bool playOnAwake = false;

        [Header ("��Ƶ�Ƿ�ѭ������")]
        public bool loop = false;
    }
    /// <summary>
    /// �洢���е���Ƶ��Ϣ
    /// </summary>
    public List<Sound> sounds;
    /// <summary>
    /// ÿһ����Ƶ���ƶ�Ӧһ����Ƶ���
    /// </summary>
    private Dictionary<string, AudioSource> audiosDic;
    /// <summary>
    /// ����
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
                Debug.LogError("�б���Ƶ����δ��ֵ");
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
    /// ����ĳһ����Ƶ
    /// </summary>
    /// <param name="name">��Ƶ����</param>
    /// <param name="isWait">�Ƿ�ȴ���Ƶ������</param>
    public static void PlayAudio(string name ,bool isWait = false)
    {
        if(!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"��Ϊ{name}��Ƶ������");
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
    /// ֹͣĳһ��Ƶ�Ĳ���
    /// </summary>
    /// <param name="name">��Ƶ����</param>
    public static  void StopAudio(string name)
    {
        if (!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"��Ϊ{name}��Ƶ������");
            return;
        }
        instance.audiosDic[name].Stop();
        
    }
    /// <summary>
    /// ��ȡ��ƵԴ
    /// </summary>
    /// <param name="name">��Ƶ����</param>
    /// <returns></returns>
    public static AudioSource GetAudioSoure(string name)
    {
        if(!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"��Ϊ{name}��Ƶ������");
            return null;
        }
        else
        {
            return instance.audiosDic[name];
        }
    }
}
