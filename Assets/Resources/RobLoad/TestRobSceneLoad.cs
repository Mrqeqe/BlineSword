 
using UnityEngine;

public class TestRobSceneLoad : MonoBehaviour
{

    void Update()
    {

        LoadScence();

    }
    public void LoadScence()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("RobLoad/RobLoadCanvas"));

            go.GetComponent<SceneLoad>().TargetSceneName = "B";
        }

       
    }
}
