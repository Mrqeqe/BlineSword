using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCenterItem : MonoBehaviour
{

    /// <summary>
    /// 按钮组件
    /// </summary>
    public Button itemBtn;
    /// <summary>
    /// Image组件
    /// </summary>
    public Image itemImage;
    /// <summary>
    /// 索引
    /// </summary>
    public int itemIndex;


    /// <summary>
    /// 初始化并获取组件
    /// </summary>
    public void InitAutoCenterItem()
    {
        itemBtn = this.GetComponent<Button>();
        itemImage = this.GetComponent<Image>();
    }
}
