using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatParticleAwake : MonoBehaviour
{
    public int ID = 1;
    void Start()
    {
        NoteManger.Instance.OnperfectBeat += PerfectBeatHandle;
    }

    private void PerfectBeatHandle(Kore_EventNodeData.NotePostion NP)
    {
        if(((int)NP) == ID)
        {
            GetComponent<ParticleSystem>().Play();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
