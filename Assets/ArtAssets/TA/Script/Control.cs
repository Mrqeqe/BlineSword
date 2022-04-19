using UnityEngine;


public class Control : MonoBehaviour
{
    //int radiusID1,radiusID2, circleWidthID1, circleWidthID2, seperateDisID1, seperateDisID2, blurAlphaID;
    [Header("")]
    [Header("������ɫ")]
    public Color Color = Color.white;
    Material m1, m2;

    [Header("Բ��")]
    [Tooltip("Բ���뾶")]
    public float cirqueRadius;
    [Tooltip("ģ�����")]
    public float cirqueBlurWidth;

    [Tooltip("ɫ�໷�������")]
    public float cirqueSeperateDis;
    [Tooltip("Բ�����")]
    public float cirqueWidth;


    [Header("����")]
    [Tooltip("���ΰ뾶")]
    public float haloRadius;
    [Tooltip("ģ�����")]
    public float haloBlurWidth;
    [Tooltip("ɫ�໷�������")]
    public float haloSeperateDis;
    [Range(0f, 1f)]
    [Tooltip("͸����")]
    public float blurAlpha;

    private void Awake()
    {
        GameObject g1 = transform.GetChild(0).gameObject;
        GameObject g2 = transform.GetChild(1).gameObject;
        Renderer r1 = g1.GetComponent<MeshRenderer>();
        Renderer r2 = g2.GetComponent<MeshRenderer>();
        if (r1 == null || r2 == null)
        {
            Debug.Log("ȱ��MeshRenderer���");
        }
        m1 = r1.material;
        m2 = r2.material;
        
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        m1.SetColor("_Color", Color);
        m2.SetColor("_Color", Color);
        m1.SetFloat("_Radius", cirqueRadius / 10f);
        m2.SetFloat("_Radius", haloRadius / 10f);
        m1.SetFloat("_CircleWidth", cirqueWidth / 100f);

        m1.SetFloat("_BlurWidth", cirqueBlurWidth / 100f);
        m2.SetFloat("_BlurWidth", haloBlurWidth / 100f);
        m1.SetFloat("_SeperateDis", cirqueSeperateDis / 10f);
        m2.SetFloat("_SeperateDis", haloSeperateDis / 10f);
        m2.SetFloat("_Alpha", blurAlpha);
    }
}
