using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBegin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-41, 32, -65);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
