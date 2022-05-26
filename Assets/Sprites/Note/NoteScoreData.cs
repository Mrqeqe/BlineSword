using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScoreData : MonoBehaviour
{
    public static NoteScoreData Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public  ScoreData Score ;
    [System.Serializable]
    public  class ScoreData
    {
        [Header("分数相关")]

        [Tooltip("音符完美击败得分")]
        [SerializeField]
        public float perfectBeatScore = 10.0f;

        [Tooltip("音符普通击败得分")]
        [SerializeField]
        public float normalBeatScore = 5.0f;

        [Tooltip("音符失败扣除血量")]
        [SerializeField]
        public float cutHealth = 10.0f;

        [Tooltip("音符完美剑心得分")]
        [SerializeField]
        public float perfectSwordHeartScore = 10.0f;

        [Tooltip("音符普通剑心得分")]
        [SerializeField]
        public float normalSwordHeartScore = 5.0f;

        [Tooltip("心魔增加值")]
        [SerializeField]
        public float heartDemoScore = 10.0f;
    }
}
