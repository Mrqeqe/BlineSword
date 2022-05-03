using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoCenterView : MonoBehaviour,IDragHandler,IEndDragHandler
{
    /// <summary>
    /// 中心容器
    /// </summary>
    public Transform container;
    /// <summary>
    /// 滑动组件
    /// </summary>
    public ScrollRect scrollRect;
    /// <summary>
    /// 布局组件
    /// </summary>
    public LayoutGroup layoutGroup = null;
    /// <summary>
    /// 当前中心元素索引
    /// </summary>
    public int curCenterChildIndex = 0;
    /// <summary>
    /// 当前中心元素对象
    /// </summary>
    public GameObject CurCenterChildItem
    {
        get
        {
            GameObject centerChild = null;
            if(container !=null && curCenterChildIndex>=0&&curCenterChildIndex<container.childCount)
            {
                centerChild = container.GetChild(curCenterChildIndex).gameObject;
            }
            return centerChild;
        }
    }
    /// <summary>
    /// 存储元素位置
    /// </summary>
    [SerializeField]
    private List<float> childrenPos = new List<float>();
    /// <summary>
    /// 容器要移动到的目标位置
    /// </summary>
    private float targetPos;
    /// <summary>
    /// 居中速度
    /// </summary>
    public float centerSpeed = 20.0f;
    /// <summary>
    /// 是否正在居中
    /// </summary>
    public bool centering = true;
    /// <summary>
    /// 是否正在缩放
    /// </summary>
    public bool scaleing = true;
    /// <summary>
    /// 缩放比例
    /// </summary>
    public Vector3 centerChildScale = new Vector3(1.2f, 1.2f, 1.2f);


    private void Awake()
    {
        InitView();
    }

    private void Update()
    {
        if(centering)
        {
            if(layoutGroup is GridLayoutGroup)
            {
                Vector3 v = container.localPosition;
                v.x = Mathf.Lerp(container.localPosition.x, targetPos, centerSpeed * Time.deltaTime);
                container.localPosition = v;
            }
        }

        if(scaleing)
        {
            for (int i = 0; i < container.childCount; i++)
            {
               
                if(i == curCenterChildIndex)
                {
                    container.GetChild(i).transform.localScale = new Vector3
                        (Mathf.Lerp(CurCenterChildItem.transform.localScale.x, centerChildScale.x, centerSpeed * Time.deltaTime),
                         Mathf.Lerp(CurCenterChildItem.transform.localScale.y, centerChildScale.y, centerSpeed * Time.deltaTime),
                         Mathf.Lerp(CurCenterChildItem.transform.localScale.z, centerChildScale.z, centerSpeed * Time.deltaTime)
                        );
                }
                else
                {
                    container.GetChild(i).transform.localScale = new Vector3
                        (
                            Mathf.Lerp(container.GetChild(i).transform.localScale.x, 1f, centerSpeed * Time.deltaTime),
                            Mathf.Lerp(container.GetChild(i).transform.localScale.x, 1f, centerSpeed * Time.deltaTime),
                            Mathf.Lerp(container.GetChild(i).transform.localScale.x, 1f, centerSpeed * Time.deltaTime)

                        );
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        centering = false;
        if(layoutGroup is LayoutGroup)
        {
            targetPos = FindClosesPos(container.localPosition.x);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        centering = true;
        if (layoutGroup is LayoutGroup)
        {
            targetPos = FindClosesPos(container.localPosition.x);
        }

    }





    /// <summary>
    /// 初始化
    /// </summary>
    public void InitView()
    {
        //获取滑动组件
        scrollRect = this.GetComponent<ScrollRect>();
        //获取容器
        container = scrollRect.content;
        //将移动方式设置为无限制
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        //获取布局组件
        layoutGroup = container.GetComponent<LayoutGroup>();

        if(layoutGroup is GridLayoutGroup)
        {
            GridLayoutGroup grid;
            grid = container.GetComponent<GridLayoutGroup>();
            //计算第一个元素的居中位置
            float childPosX = scrollRect.GetComponent<RectTransform>().rect.width * 0.5f - grid.cellSize.x * 0.5f;
            childrenPos.Add(childPosX);
            //存储所有子物体位于中心是的位置
            for (int i = 0; i < container.childCount-1; i++)
            {
                childPosX -= grid.cellSize.x + grid.spacing.x;
                childrenPos.Add(childPosX);
            }
            //将当前容器的x坐标传入，获取当前居中的位置
            targetPos = FindClosesPos(container.localPosition.x);
        }
    }
    /// <summary>
    /// 寻找最近的中心元素
    /// </summary>
    /// <param name="currentPos">当前位置，可传入X或者Y</param>
    /// <returns>返回相应的位置坐标</returns>
    private float FindClosesPos(float currentPos)
    {
        int childIndex = 0;
        float closest = 0;
        curCenterChildIndex = -1;
        float distance = Mathf.Infinity;

        //查找最近的子物体位置
        for (int i = 0; i < childrenPos.Count; i++)
        {
            float p = childrenPos[i];
            float d = Mathf.Abs(p - currentPos);
            if(d<distance)
            {
                distance = d;
                closest = p;
                childIndex = i;
            }
        }
        //设置当前中心元素索引
        curCenterChildIndex = childIndex;
        return closest;
    }
    /// <summary>
    /// 改变中心元素
    /// </summary>
    /// <param name="index">目标索引</param>
    public void SetCenterChild(int index)
    {
        curCenterChildIndex = index;
        targetPos = childrenPos[index];
    }
}
