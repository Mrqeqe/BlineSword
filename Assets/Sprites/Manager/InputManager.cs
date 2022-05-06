using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    /// <summary>
    /// ���������
    /// </summary>
    public static InputManager Instance { get; set; }
    public bool isGamePause = false;
    /// <summary>
    /// �������״̬ö��ֵ
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
    /// ��ҵ�ǰ����ö��
    /// </summary>
    private static PlayerInput playerInput;

    /// <summary>
    /// ������¼�
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
    /// ���������뼤��OnMouseClicked�¼����л�����ö��
    /// </summary>
    private void PlayerAction()
    {
        #region �ɴ��룬��ע��
        //��߰�סͬʱ�ұ߰��»����ұ߰�ס��߰��»�������ͬʱ����
        //if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)
        //    || Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)
        //    || Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1)
        //   )
        //{
        //playerInput = PlayerInput.Mouseboth;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("�������ͬʱ����");
        //}

        //else if (Input.GetMouseButtonDown(0))
        //{
        //    playerInput = PlayerInput.Mouseleft;
        //    OnMouseClicked.Invoke(playerInput);
        //     Debug.Log("����������");
        //}
        //else if(Input.GetMouseButtonDown(1))
        //{
        //    playerInput = PlayerInput.Mouseright;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("��������Ҽ�");
        //}

        //��߰�סͬʱ�ұ߰��»����ұ߰�ס��߰��»�������ͬʱ����
        //if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J)
        //    || Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.F)
        //    || Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J)
        //   )
        //{
        //    playerInput = PlayerInput.Mouseboth;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("�������ͬʱ����");
        //}

        //else if (Input.GetKeyDown(KeyCode.F))
        //{
        //    playerInput = PlayerInput.Mouseleft;
        //    OnMouseClicked.Invoke(playerInput);
        //     Debug.Log("����������");
        //}
        //else if (Input.GetKeyDown(KeyCode.J))
        //{
        //    playerInput = PlayerInput.Mouseright;
        //    OnMouseClicked.Invoke(playerInput);
        //    Debug.Log("��������Ҽ�");
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