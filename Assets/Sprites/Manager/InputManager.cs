using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    /// <summary>
    /// 输入管理单例
    /// </summary>
    public static InputManager Instance { get; set; }
    public bool isGamePause = false;
    /// <summary>
    /// 玩家输入状态枚举值
    /// </summary>
    public  enum PlayerInput
    {
        E,
        R,
        U,
        I,
        D,
        F,
        J,
        K
    }

    /// <summary>
    /// 玩家当前输入枚举
    /// </summary>
    private static PlayerInput playerInput;

    /// <summary>
    /// 鼠标点击事件
    /// </summary>
    public event Action<PlayerInput> OnKeyPassed;

    public event Action<bool> OnGamePused;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    
     void Update()
    {
        PuseGame();
        
        if(!isGamePause)
        {
            PlayerAction();
        }
        
    }

    /// <summary>
    /// 检测玩家输入激活OnMouseClicked事件，切换输入枚举
    /// </summary>
    private void PlayerAction()
    {
        #region 旧代码，已注释
        //左边按住同时右边按下或者右边按住左边按下或者左右同时按下
        //if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)
        //    || Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)
        //    || Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1)
        //   )
        //{
        //playerInput = PlayerInput.Mouseboth;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("鼠标左右同时按下");
        //}

        //else if (Input.GetMouseButtonDown(0))
        //{
        //    playerInput = PlayerInput.Mouseleft;
        //    OnMouseClicked.Invoke(playerInput);
        //     Debug.Log("按下鼠标左键");
        //}
        //else if(Input.GetMouseButtonDown(1))
        //{
        //    playerInput = PlayerInput.Mouseright;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("按下鼠标右键");
        //}

        //左边按住同时右边按下或者右边按住左边按下或者左右同时按下
        //if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J)
        //    || Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.F)
        //    || Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J)
        //   )
        //{
        //    playerInput = PlayerInput.Mouseboth;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("鼠标左右同时按下");
        //}

        //else if (Input.GetKeyDown(KeyCode.F))
        //{
        //    playerInput = PlayerInput.Mouseleft;
        //    OnMouseClicked.Invoke(playerInput);
        //     Debug.Log("按下鼠标左键");
        //}
        //else if (Input.GetKeyDown(KeyCode.J))
        //{
        //    playerInput = PlayerInput.Mouseright;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("按下鼠标右键");
        //}
        #endregion
       
       if(Input.GetKeyDown(KeyCode.E))
        {
            playerInput = PlayerInput.E;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.R))
        {
            playerInput = PlayerInput.R;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.U))
        {
            playerInput = PlayerInput.U;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.I))
        {
            playerInput = PlayerInput.I;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.D))
        {
            playerInput = PlayerInput.D;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.F))
        {
            playerInput = PlayerInput.F;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.J))
        {
            playerInput = PlayerInput.J;
            OnKeyPassed.Invoke(playerInput);
        }if(Input.GetKeyDown(KeyCode.K))
        {
            playerInput = PlayerInput.K;
            OnKeyPassed.Invoke(playerInput);
        }
    }
    private void PuseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePause = !isGamePause;
            OnGamePused.Invoke(isGamePause);
            Debug.Log(isGamePause);
        }
    }
}