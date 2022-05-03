using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


/// <summary>
/// 设置管理
/// </summary>
public class SettingManager : MonoBehaviour
{
    [Header("音频混响器")]
    public AudioMixer mixer;


    public AudioSource KereAudioSource;
    void Start()
    {
        InputManager.Instance.OnGamePused += PauseOrUnpauseGame;
    }

    private void PauseOrUnpauseGame(bool isPauseGame)
    {
       if(isPauseGame)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    private void PauseGame()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
        //暂停插件的播放
        KereAudioSource.Pause();
    }
    /// <summary>
    /// 设置Bgm音量值
    /// </summary>
    /// <param name="value"></param>
    public void SetBGMValue(float value)
    {
        mixer.SetFloat("BGM", value);
    }
    /// <summary>
    /// 设置音效音量值
    /// </summary>
    /// <param name="value"></param>
    public void SetSFXValue (float value)
    {
        mixer.SetFloat("SFX", value);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        KereAudioSource.UnPause();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
      
    }
    public void UnPauseBtu()
    {
        UnpauseGame();
      InputManager.Instance.isGamePause = !InputManager.Instance.isGamePause;
    }

}
