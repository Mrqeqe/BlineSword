using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


/// <summary>
/// ���ù���
/// </summary>
public class SettingManager : MonoBehaviour
{
    [Header("��Ƶ������")]
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
        //��ͣ����Ĳ���
        KereAudioSource.Pause();
    }
    /// <summary>
    /// ����Bgm����ֵ
    /// </summary>
    /// <param name="value"></param>
    public void SetBGMValue(float value)
    {
        mixer.SetFloat("BGM", value);
    }
    /// <summary>
    /// ������Ч����ֵ
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
