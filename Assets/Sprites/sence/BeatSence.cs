using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSence : MonoBehaviour
{

    public static BeatSence Instance { get; set; }
    private bool isShaking=false;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraShake(float duration ,float strength)
    {
        StartCoroutine(ShakeCamera(duration,strength));
    }
    IEnumerator ShakeCamera(float duration,float strength)
    {
        isShaking = true;
        Transform camera = Camera.main.transform;
        Vector3 orginPostion = camera.position;
        while(duration >0)
        {
            camera.position = Random.insideUnitSphere * strength + orginPostion;
            duration -= Time.deltaTime;
            yield return null;
        }
        isShaking = false;
    }
}
