using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject RayCastIndicator;

    public GameObject Player;

    //Hands
    public GameObject RightHand;
    public GameObject LeftHand;

    public Rigidbody TearMesh;
    public Transform FirePosition;
    public GameObject PickPosition;

    private Quaternion original1;
    private Quaternion original2;

    bool is_holding = false;
    private GameObject held_obj;

    public AudioSource audios;

    // public Vector3 Cam_Offset ;
    //Gameplay properaties
    int Health = 200;

    void start()
    {
        
        original1 = RightHand.transform.rotation;
        audios = GetComponent<AudioSource>();
    }
    void Update() {


        Vector3 forward = transform.TransformDirection(Vector3.forward);

       // Debug.Log(this.transform.rotation.eulerAngles.x);
        if (this.transform.rotation.eulerAngles.x > 350)
        {
            RightHand.transform.SetParent(PickPosition.transform);
            RightHand.transform.localPosition = new Vector3(0.38f, 0.1f, -0.47f);
            RightHand.transform.rotation = original1;
            LeftHand.transform.SetParent(PickPosition.transform);
            LeftHand.transform.localPosition = new Vector3(-0.5f, 0.1f, -0.33f);
            LeftHand.transform.rotation = original1;


        }
        else if
       ((this.transform.rotation.eulerAngles.x >= 0 && this.transform.rotation.eulerAngles.x < 80))
        {
            RightHand.transform.SetParent(PickPosition.transform);
            RightHand.transform.localPosition = new Vector3(0.38f, 0.1f, -0.47f);
            LeftHand.transform.SetParent(PickPosition.transform);
            LeftHand.transform.localPosition = new Vector3(-0.5f, 0.1f, -0.33f);
            RightHand.transform.rotation = original1;
            LeftHand.transform.rotation = original1;


        }
        else
        {
            RightHand.transform.SetParent(null);
            LeftHand.transform.SetParent(null);
            

        }

        // and we add a ray cast hit to mark where we are looking at
        RaycastHit raycastHit;

        // if the ray hits something, the ray starts from our location
        // goes in forward direction
        // and its max length is 20

        // if it hits something , we will enter in the if 
        //Debug.DrawRay(transform.position, forward * 500);
        if (Physics.Raycast(transform.position, forward, out raycastHit, 70))
        {

            // if it's a floor , we can do our magic and teleport
            if (raycastHit.collider.gameObject.tag == "Floor")
            {
                //Debug.Log("Hello");
                RayCastIndicator.SetActive(true);
                RayCastIndicator.transform.position = raycastHit.point;
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    iTween.MoveTo(Player,
                        iTween.Hash(
                            "position", new Vector3(raycastHit.point.x, raycastHit.point.y + 1, raycastHit.point.z),
                             "time", .2f,
                             "easetype", "linear")

                                    );
                }
            }


            else if (raycastHit.collider.gameObject.tag == "Pickable")
            {
               //Debug.Log("PickMe");
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                   // raycastHit.collider.gameObject.GetComponent<Rigidbody>().
                    raycastHit.collider.gameObject.transform.SetParent(RightHand.transform);
                    raycastHit.collider.gameObject.transform.localPosition = new Vector3(0f, 0f, 0);
                    held_obj = raycastHit.collider.gameObject;
                    original2 = held_obj.transform.rotation;



                }
            }
            // if not , we can fire a bullet
            // the bullet takes the position and rotation of the fire position

            else
            {
                RayCastIndicator.SetActive(false);
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    audios.Play(0);
                    Rigidbody Tear = Instantiate(TearMesh, FirePosition.position, FirePosition.rotation);
                    Tear.AddForce(forward * 600);

                }
            }

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.JoystickButton1) )
            {
                
                held_obj.transform.SetParent(null);

                held_obj.transform.position = new Vector3(held_obj.transform.position.x, 0.1f, held_obj.transform.position.z);
                held_obj.transform.rotation.Set(original2.x, original2.y, original2.z, 1);


            }
        }







    }


}
