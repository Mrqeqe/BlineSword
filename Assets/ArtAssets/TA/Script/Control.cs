using UnityEngine;


public class Control : MonoBehaviour
{
    //int radiusID1,radiusID2, circleWidthID1, circleWidthID2, seperateDisID1, seperateDisID2, blurAlphaID;
    [Header("")]
    [Header("整体颜色")]
    public Color Color = Color.white;
    Material m1, m2;

    [Header("圆环")]
    [Tooltip("圆环半径")]
    public float cirqueRadius;
    [Tooltip("模糊宽度")]
    public float cirqueBlurWidth;

    [Tooltip("色相环分离距离")]
    public float cirqueSeperateDis;
    [Tooltip("圆环宽度")]
    public float cirqueWidth;


    [Header("光晕")]
    [Tooltip("光晕半径")]
    public float haloRadius;
    [Tooltip("模糊宽度")]
    public float haloBlurWidth;
    [Tooltip("色相环分离距离")]
    public float haloSeperateDis;
    [Range(0f, 1f)]
    [Tooltip("透明度")]
    public float blurAlpha;

    private void Awake()
    {
        GameObject g1 = transform.GetChild(0).gameObject;
        GameObject g2 = transform.GetChild(1).gameObject;
        Renderer r1 = g1.GetComponent<MeshRenderer>();
        Renderer r2 = g2.GetComponent<MeshRenderer>();
        if (r1 == null || r2 == null)
        {
            Debug.Log("缺少MeshRenderer组件");
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
