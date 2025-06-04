using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject ItemOnPlayer;
    public GameObject PickUpText;
    void Start()
    {
        ItemOnPlayer.SetActive(false);

        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                ItemOnPlayer.SetActive(true);

                PickUpText.SetActive(false);

            }
        }
   
    }
    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
