using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEnd : MonoBehaviour
{
    public GameObject toEndPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
           toEndPrefab.SetActive(true);
           other.gameObject.SetActive(false); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
