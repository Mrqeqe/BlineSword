using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSilderAnimChanged : MonoBehaviour
{
    public void setFireGrewFalse()
    {
        Animator hpAnim = this.GetComponent<Animator>();
        hpAnim.SetBool("FireGrew", false);
        Debug.Log("FireGrew");
    }
    public void setFireDownFalse()
    {
        Animator hpAnim = this.GetComponent<Animator>();
        hpAnim.SetBool("FireDown", false);
        Debug.Log("FireDown");
    }
}
