using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHearScoreToZero : MonoBehaviour
{
   
    public void SwordHeartToZero()
    {
        ScoringManager.Instance.UIScore.CurentSwordHeartScore = 0;
        Debug.Log("����Ϊ0"+ ScoringManager.Instance.UIScore.CurentSwordHeartScore);
    }
}
