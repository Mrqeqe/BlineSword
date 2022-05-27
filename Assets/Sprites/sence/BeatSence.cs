using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSence : MonoBehaviour
{

    public static BeatSence Instance { get; set; }
    private bool isShaking=false;
    Vector3 orginTrans;
    private void Awake()
    {
        if(Instance !=null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        orginTrans = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 屏幕震动
    /// </summary>
    /// <param name="duration">持续时间</param>
    /// <param name="strength">强度</param>
    public void CameraShake(float duration ,float strength)
    {
        StartCoroutine(ShakeCamera(duration,strength));
    }
    IEnumerator ShakeCamera(float duration,float strength)
    {
        isShaking = true;
        Transform camera = Camera.main.transform;
        
        while(duration >0)
        {
            camera.position = Random.insideUnitSphere * strength + orginTrans;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position = orginTrans;
       isShaking = false;
    }
}
