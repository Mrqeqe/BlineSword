using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugeRangeControl : MonoBehaviour
{
    public Transform perfectBg;
    public Transform normalBg;
    public Transform fireParticle;
   
    private void Start()
    {
        perfectBg.localScale = new Vector3(ScoringManager.Instance.perfectJudgmentRange * 2, ScoringManager.Instance.perfectJudgmentRange * 2, 1);
        normalBg.localScale = new Vector3(ScoringManager.Instance.normalJugmentRange * 2, ScoringManager.Instance.normalJugmentRange * 2, 0);
        fireParticle.localScale = new Vector3(ScoringManager.Instance.perfectJudgmentRange * 4, ScoringManager.Instance.perfectJudgmentRange * 4, 1);
        
    }

    void Update()
    {
        if (ScoringManager.Instance.UIScore.CurentSwordHeartScore >= ScoringManager.Instance.UIScore.SwordHeartScore)
        {
            fireParticle.gameObject.SetActive(true);
        }
        else
        {
            fireParticle.gameObject.SetActive(false);
        }
    }
}
