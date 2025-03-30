using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscared : MonoBehaviour
{

    public GameObject Bleh;
    public GameObject uhuh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            uhuh.SetActive(true);
            Bleh.SetActive(true);
            this.gameObject.SetActive(false);

            new WaitForSeconds(3);
             
            // if (!Muhahaha.active){
            // mahmah.SetActive(true);
            // StartCoroutine(popoi());
            // }
        }
        
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
