using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCenterController : MonoBehaviour
{
    /// <summary>
    /// 所有元素列表
    /// </summary>
    public List<AutoCenterItem> autoCenterItems = new List<AutoCenterItem>();
    /// <summary>
    /// 居中效果脚本
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
        //获取居中效果脚本
        autoCenterView = GetComponent<AutoCenterView>();
        Transform container = autoCenterView.container;
        //获取所有容器内元素
        for (int i = 0; i < container.childCount; i++)
        {
            AutoCenterItem temp = container.GetChild(i).GetComponent<AutoCenterItem>();
            autoCenterItems.Add(temp);
            //调用元素初始化方法
            temp.InitAutoCenterItem();
            //给元素的Btton绑定点击事件
            temp.itemBtn.onClick.AddListener(() =>
            {
                OnIntemClick(temp.itemIndex);
            });
        }
    }

    /// <summary>
    /// 当点击容器内元素时触发
    /// </summary>
    /// <param name="index"></param>
    public void OnIntemClick(int index)
    {
        autoCenterView.SetCenterChild(index);
    }
    /// <summary>
    /// 键盘切换中心元素
    /// </summary>
    public void OnInput()
    {
        int index = autoCenterView.curCenterChildIndex;

            if ((Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)) && index >= 0 && index <= autoCenterView.container.childCount - 2)
            {
               // Debug.Log("加1");
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
