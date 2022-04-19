using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleNote : MonoBehaviour
{
    /// <summary>
    /// 两个音符模型间的距离
    /// </summary>
    private float distance;
    private Transform myTrans;
    private Control scoreControl;
    private Control childControl;
    void Start()
    {
        myTrans = GetComponent<Transform>();
        distance = NoteManger.Instance.rightInsTrans.position.x - NoteManger.Instance.leftInsTrans.position.x;
        scoreControl = this.GetComponent<Control>();
        childControl = myTrans.GetChild(2).GetComponent<Control>();
        myTrans.GetChild(2).position = myTrans.GetChild(2).position + new Vector3(distance, 0, 0);
    }
    void Update()
    {
        
        childControl.Color = scoreControl.Color;
        childControl.cirqueRadius = scoreControl.cirqueRadius;
        childControl.cirqueBlurWidth = scoreControl.cirqueBlurWidth;
        childControl.cirqueSeperateDis = scoreControl.cirqueSeperateDis;
        childControl.cirqueWidth = scoreControl.cirqueWidth;

        childControl.haloRadius = scoreControl.haloRadius;
        childControl.haloSeperateDis = scoreControl.haloSeperateDis;
        childControl.haloBlurWidth = scoreControl.haloBlurWidth;

        childControl.blurAlpha = scoreControl.blurAlpha;
  
    }
}

