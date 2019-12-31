using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set the main Color of the Material to green

public class is_being_collided : MonoBehaviour
{
    public Material defaultMaterial;
    public Material lightUpMaterial;
    public bool on = false;

    void Start()
    {
        defaultMaterial = this.GetComponent<MeshRenderer>().material;


    }
   
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

        if (hitColliders.Length > 2)
        {
            this.GetComponent<MeshRenderer>().material = lightUpMaterial;
            on = true;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = defaultMaterial;
            on = false;
        }
        
    }
}
