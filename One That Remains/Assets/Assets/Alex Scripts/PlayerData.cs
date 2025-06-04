using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas2 : MonoBehaviour
{
    public int keys;
    public GameObject count;


    public bool blebleble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
        
    // }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("blebleble"))
        {
            blebleble = true;
        } 
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.CompareTag("blebleble"))
        {
            blebleble = false;
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
        
    // }
    // Update is called once per frame
    void Update()
    {
        if (keys == 1)
        {
            count.SetActive(true);
        }
    }
}
