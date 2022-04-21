using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCenterItem : MonoBehaviour
{

    /// <summary>
    /// ��ť���
    /// </summary>
    public Button itemBtn;
    /// <summary>
    /// Image���
    /// </summary>
    public Image itemImage;
    /// <summary>
    /// ����
    /// </summary>
    public int itemIndex;


    /// <summary>
    /// ��ʼ������ȡ���
    /// </summary>
    public void InitAutoCenterItem()
    {
        itemBtn = this.GetComponent<Button>();
        itemImage = this.GetComponent<Image>();
    }
}
