using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject target;
    public GameObject image;



    private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitForJump());
            target.SetActive(true);
            StartCoroutine(WaitForJumpscare());
            }
        //  else if(other.CompareTag("Player"))
        // {
        //     StartCoroutine(Cooldown());
        // }
     }
    //  IEnumerator Cooldown()
    //  {
    //     yield return new WaitForSeconds(8);
    //     trajectoryHeight = false;
    //     new WaitForSeconds(4);
    //     trajectoryHeight = true;
    //  }
     IEnumerator WaitForJumpscare()
     {
        yield return new WaitForSeconds(17);
        target.SetActive(false);
        image.SetActive(false);
     }
     IEnumerator WaitForJump()
     {
        yield return new WaitForSeconds(9);
        image.SetActive(true);
        CameraShake.Shake(8f, 2f);
     }
}

