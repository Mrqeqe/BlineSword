using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Image exitImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitImage.gameObject.SetActive(true);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ÍË³ö");
    }
    public void Cancle()
    {
        exitImage.gameObject.SetActive(false);
    }
}
