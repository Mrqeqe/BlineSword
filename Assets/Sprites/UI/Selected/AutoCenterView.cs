using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoCenterView : MonoBehaviour,IDragHandler,IEndDragHandler
{
    /// <summary>
    /// ��������
    /// </summary>
    public Transform container;
    /// <summary>
    /// �������
    /// </summary>
    public ScrollRect scrollRect;
    /// <summary>
    /// �������
    /// </summary>
    public LayoutGroup layoutGroup = null;
    /// <summary>
    /// ��ǰ����Ԫ������
    /// </summary>
    public int curCenterChildIndex = 0;
    /// <summary>
    /// ��ǰ����Ԫ�ض���
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
    /// �洢Ԫ��λ��
    /// </summary>
    [SerializeField]
    private List<float> childrenPos = new List<float>();
    /// <summary>
    /// ����Ҫ�ƶ�����Ŀ��λ��
    /// </summary>
    private float targetPos;
    /// <summary>
    /// �����ٶ�
    /// </summary>
    public float centerSpeed = 20.0f;
    /// <summary>
    /// �Ƿ����ھ���
    /// </summary>
    public bool centering = true;
    /// <summary>
    /// �Ƿ���������
    /// </summary>
    public bool scaleing = true;
    /// <summary>
    /// ���ű���
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
    /// ��ʼ��
    /// </summary>
    public void InitView()
    {
        //��ȡ�������
        scrollRect = this.GetComponent<ScrollRect>();
        //��ȡ����
        container = scrollRect.content;
        //���ƶ���ʽ����Ϊ������
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        //��ȡ�������
        layoutGroup = container.GetComponent<LayoutGroup>();

        if(layoutGroup is GridLayoutGroup)
        {
            GridLayoutGroup grid;
            grid = container.GetComponent<GridLayoutGroup>();
            //�����һ��Ԫ�صľ���λ��
            float childPosX = scrollRect.GetComponent<RectTransform>().rect.width * 0.5f - grid.cellSize.x * 0.5f;
            childrenPos.Add(childPosX);
            //�洢����������λ�������ǵ�λ��
            for (int i = 0; i < container.childCount-1; i++)
            {
                childPosX -= grid.cellSize.x + grid.spacing.x;
                childrenPos.Add(childPosX);
            }
            //����ǰ������x���괫�룬��ȡ��ǰ���е�λ��
            targetPos = FindClosesPos(container.localPosition.x);
        }
    }
    /// <summary>
    /// Ѱ�����������Ԫ��
    /// </summary>
    /// <param name="currentPos">��ǰλ�ã��ɴ���X����Y</param>
    /// <returns>������Ӧ��λ������</returns>
    private float FindClosesPos(float currentPos)
    {
        int childIndex = 0;
        float closest = 0;
        curCenterChildIndex = -1;
        float distance = Mathf.Infinity;

        //���������������λ��
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
        //���õ�ǰ����Ԫ������
        curCenterChildIndex = childIndex;
        return closest;
    }
    /// <summary>
    /// �ı�����Ԫ��
    /// </summary>
    /// <param name="index">Ŀ������</param>
    public void SetCenterChild(int index)
    {
        curCenterChildIndex = index;
        targetPos = childrenPos[index];
    }
}
