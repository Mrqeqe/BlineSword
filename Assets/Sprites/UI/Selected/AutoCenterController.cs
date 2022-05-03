using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCenterController : MonoBehaviour
{
    /// <summary>
    /// ����Ԫ���б�
    /// </summary>
    public List<AutoCenterItem> autoCenterItems = new List<AutoCenterItem>();
    /// <summary>
    /// ����Ч���ű�
    /// </summary>
    public AutoCenterView autoCenterView;
   
    private void Start()
    {
        InitController();
    }
    private void Update()
    {
        OnInput();
    }
    public void InitController()
    {
        //��ȡ����Ч���ű�
        autoCenterView = GetComponent<AutoCenterView>();
        Transform container = autoCenterView.container;
        //��ȡ����������Ԫ��
        for (int i = 0; i < container.childCount; i++)
        {
            AutoCenterItem temp = container.GetChild(i).GetComponent<AutoCenterItem>();
            autoCenterItems.Add(temp);
            //����Ԫ�س�ʼ������
            temp.InitAutoCenterItem();
            //��Ԫ�ص�Btton�󶨵���¼�
            temp.itemBtn.onClick.AddListener(() =>
            {
                OnIntemClick(temp.itemIndex);
            });
        }
    }

    /// <summary>
    /// �����������Ԫ��ʱ����
    /// </summary>
    /// <param name="index"></param>
    public void OnIntemClick(int index)
    {
        autoCenterView.SetCenterChild(index);
    }
    /// <summary>
    /// �����л�����Ԫ��
    /// </summary>
    public void OnInput()
    {
        int index = autoCenterView.curCenterChildIndex;

            if ((Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)) && index >= 0 && index <= autoCenterView.container.childCount - 2)
            {
               // Debug.Log("��1");
                index += 1;
                autoCenterView.SetCenterChild(index);
                
            }
            else if((Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))&& index <=autoCenterView.container.childCount - 1&& index > 0)
            {
               // Debug.Log("-1");
                index -= 1;
                autoCenterView.SetCenterChild(index);
            }
        
       
    }
}
