using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suffering : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mahmah;   

    public GameObject Muhahaha;

   //  public GameObject muhheheh;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            if (!Muhahaha.active){
            mahmah.SetActive(true);
            // muhheheh.SetActive(true);
            StartCoroutine(popoi());
            }
        }
        
     }

     IEnumerator popoi()
     {
        yield return new WaitForSeconds(5);
       
        mahmah.SetActive(false);
     }
}
