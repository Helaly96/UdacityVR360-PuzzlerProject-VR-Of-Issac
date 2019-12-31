using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyUI : MonoBehaviour
{
    public bool ClickedBefore = false;
    public GameObject UI;
    void DestroyMe()
    {
        if (ClickedBefore== false)
        {
            ClickedBefore = true;
            UI.SetActive(false);
        }



    }
}
