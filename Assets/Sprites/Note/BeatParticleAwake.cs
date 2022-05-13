using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatParticleAwake : MonoBehaviour
{
    private int _id = 1;
    void Start()
    {
        NoteManger.Instance.OnperfectBeat += PerfectBeatHandle;
        _id = Convert.ToInt32(this.transform.parent.name) -1;
        Debug.Log("º”‘ÿ¡£◊”" + _id);
    }

    private void PerfectBeatHandle(Kore_EventNodeData data)
    {
        if(((int)data.NoteInsPostion) == _id)
        {
            Debug.Log(data.SfxType);
            this.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
       
    }

   
}
