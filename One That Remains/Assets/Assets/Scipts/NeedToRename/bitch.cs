using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitch : MonoBehaviour
{
    public bool behehf = true;
    // Start is called before the first frame update
    void Start()
    {
        behehf = true;
    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("enemy"))
        {
            behehf = false;
        }
    
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("s");
            behehf = false;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
