using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpscare : MonoBehaviour
{
     [SerializeField] private Animator myDoor = null;

     [SerializeField] private bool openTrigger = false;

     public GameObject heme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
                {
                    StartCoroutine(Buh());
                    // new WaitForSeconds(2f);
                    // myDoor.Play("Boom", 0, 0.0f);
                    // openTrigger = false;
                    // new WaitForSeconds(3f);
                    // this.gameObject.SetActive(false);

                }
        }
    }

    IEnumerator Buh()
    {
        yield return new WaitForSeconds(1f);
         myDoor.Play("Boom", 0, 0.0f);
         heme.SetActive(true);
         CameraShake.Shake(2f, 8f);
        openTrigger = false;
        new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
