using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugeRangeControl : MonoBehaviour
{
    public Transform perfectBg;
    public Transform normalBg;


    
    void Update()
    {
        perfectBg.localScale = new Vector3(ScoringManager.Instance.perfectJudgmentRange * 2, ScoringManager.Instance.perfectJudgmentRange * 2, 1);
        normalBg.localScale =new Vector3(ScoringManager.Instance.normalJugmentRange * 2, ScoringManager.Instance.normalJugmentRange * 2, 0);
    }
}
