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
        [Header("�������")]

        [Tooltip("�����������ܵ÷�")]
        [SerializeField]
        public float perfectBeatScore = 10.0f;

        [Tooltip("������ͨ���ܵ÷�")]
        [SerializeField]
        public float normalBeatScore = 5.0f;

        [Tooltip("����ʧ�ܿ۳�Ѫ��")]
        [SerializeField]
        public float cutHealth = 10.0f;

        [Tooltip("�����������ĵ÷�")]
        [SerializeField]
        public float perfectSwordHeartScore = 10.0f;

        [Tooltip("������ͨ���ĵ÷�")]
        [SerializeField]
        public float normalSwordHeartScore = 5.0f;

        [Tooltip("��ħ����ֵ")]
        [SerializeField]
        public float heartDemoScore = 10.0f;
    }
}
