using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public is_being_collided Obj1;
    public is_being_collided Obj2;
    public is_being_collided Obj3;
    private bool open = false;
    public MonstroAI Monstro;
    // Use this for initialization
    // Update is called once per frame
    void Update ()
    {
	    if (!open)
        {
            if ( Obj1.on  && Obj2.on && Obj3.on)
            {
                Destroy(this.gameObject);
                Monstro.wakeup = true;

            }
        }
	}
}
