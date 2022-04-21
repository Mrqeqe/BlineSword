using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

    public Text text;
    public Slider slider;
    public Image fader;

    public Animator animator;
    string targetSceneName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string TargetSceneName
    {
        set
        {
            targetSceneName = value;
            StartCoroutine(LoadScene(targetSceneName));
            //暗
            animator.Play("LoadAnimFadeIn");
        }
    }

    AsyncOperation asyncOperation;
 
    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1.2f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

       // asyncOperation.allowSceneActivation = false;
        
        while (!asyncOperation.isDone)
        {
        
            float p = asyncOperation.progress * 100 + 10f;
            if (p > 100) p = 100;
            text.text =  p + "%";

            slider.value = Mathf.Lerp(slider.value, asyncOperation.progress, Time.time);
           
            //if (asyncOperation.progress >= 0.9f)
            //{
            //    slider.value = 1;
            //    text.text = "按下任意键开始";
            //}
            //if (Input.anyKeyDown)
            //{
            //    asyncOperation.allowSceneActivation = true;
            //}

            yield return null;
        }

        while (asyncOperation.isDone)
        {

           
            slider.value= 1;

            Invoke("FadeOut", 2);
            Invoke("Destory1", 3);
            break;
        }

    }

    void FadeOut()
    {
        //亮
        animator.Play("LoadAnimFadeOut");
    }

    void Destory1()
    {
        Destroy(gameObject);
       
    }

 
}
