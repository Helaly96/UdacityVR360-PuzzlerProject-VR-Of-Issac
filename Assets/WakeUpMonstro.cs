using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpMonstro : MonoBehaviour {

    public MonstroAI Monstro;

	void OnTriggerEnter(Collider coli)
    {
        Monstro.wakeup = true;
    }


}
