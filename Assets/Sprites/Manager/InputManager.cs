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

    /// <summary>
    /// �������״̬ö��ֵ
    /// </summary>
    public  enum PlayerInput
    {
        Mouseleft,
        Mouseright,
        Mouseboth,
    }

    /// <summary>
    /// ��ҵ�ǰ����ö��
    /// </summary>
    private static PlayerInput playerInput;

    /// <summary>
    /// ������¼�
    /// </summary>
    public event Action<PlayerInput> OnMouseClicked;

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
        PlayerAction();
    }

    /// <summary>
    /// ���������뼤��OnMouseClicked�¼����л�����ö��
    /// </summary>
    private void PlayerAction()
    {
        //��߰�סͬʱ�ұ߰��»����ұ߰�ס��߰��»�������ͬʱ����
        if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)
            || Input.GetMouseButton(1) && Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1)
           )
        {
        playerInput = PlayerInput.Mouseboth;
            OnMouseClicked.Invoke(playerInput);
            Debug.Log("�������ͬʱ����");
        }

        else if (Input.GetMouseButtonDown(0))
        {
            playerInput = PlayerInput.Mouseleft;
            OnMouseClicked.Invoke(playerInput);
            // Debug.Log("����������");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            playerInput = PlayerInput.Mouseright;
            OnMouseClicked.Invoke(playerInput);
            //Debug.Log("��������Ҽ�");
        }
        
    }
}