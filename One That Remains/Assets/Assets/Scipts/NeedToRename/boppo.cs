using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boppo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject POPOI;

    public GameObject BOOMBA;
    
    
    void Update()
    {
        if(POPOI.active)
        {
            BOOMBA.SetActive(true);
        }
        
    }

    
}
