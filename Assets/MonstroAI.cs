using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroAI : MonoBehaviour {

    public GameObject Issac;
    public Rigidbody TearMesh;
    public Transform FirePosition;

    public GameObject Monstro;

    float bulletdelay = 0.5f;
    bool flipflop = true;
    public bool wakeup = false;

    public int Health = 100;

    public GameObject WinnerWinnerChickenDinner;

    // Use this for initialization
    void Start () {
		
	}
	
    void Attack()
    {
        Rigidbody Tear = Instantiate(TearMesh, FirePosition.position, FirePosition.rotation);
        Tear.AddForce( transform.TransformDirection(Vector3.forward) );
    }

    void Move()
    {
        iTween.MoveTo(Monstro,
                        iTween.Hash(
                            "position", new Vector3(Issac.transform.position.x - 0.5f , Issac.transform.position.y - 1 , Issac.transform.position.z - 2),
                             "time", .5f,
                             "easetype", "linear")

                                    );
    }

	// Update is called once per frame
	void Update ()
    {
        if (wakeup)
        {
            if (flipflop)
            {
                 Invoke("Move", 4f);
                 flipflop = !flipflop;

            }
            else
            {
                Invoke("Attack", 4f);
                flipflop = !flipflop;
            }

        }

        if (Health == 0)
        {
            WinnerWinnerChickenDinner.SetActive(true);
            Destroy(this.gameObject);


        }
        
		
	}

    void OnTriggerEnter(Collider coli)
    {
       if (coli.gameObject.tag == "tear")
        {
            this.Health = this.Health - 20;
        }
    }
}
