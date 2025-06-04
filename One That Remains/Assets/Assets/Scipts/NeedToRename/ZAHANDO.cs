using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAHANDO : MonoBehaviour
{
    public GameObject HANDO;

    public PlayerDatas hando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            if(hando.keys <= 2)
                HANDO.SetActive(true);
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
