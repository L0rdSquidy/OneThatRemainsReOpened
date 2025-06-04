using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAMAMIA : MonoBehaviour
{
     public GameObject mahmah;   

    public GameObject Muhahaha;

    public GameObject Muhahahahaha;

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
            Muhahaha.SetActive(false);
            // muhheheh.SetActive(true);
            // StartCoroutine(popoi());
            } else if (Muhahaha.active)
            {
                mahmah.SetActive(true);
                Muhahahahaha.SetActive(false);
            }
        }
        
     }

    //  IEnumerator popoi()
    //  {
    //     yield return new WaitForSeconds(5);
       
    //     mahmah.SetActive(false);
    //  }
}
