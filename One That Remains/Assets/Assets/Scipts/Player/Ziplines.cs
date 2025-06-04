using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float checkoffset = 1f;
    [SerializeField] private float checkradius = 1f;

    private HP hpScript;
    public KeyCode Zipkey = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        hpScript = FindObjectOfType<HP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Zipkey))
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position + new Vector3(0, checkoffset, 0), checkradius, Vector3.up);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "zipline")
                {
                    hit.collider.GetComponent<Zipline>().startzipping(gameObject);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            hpScript.AddScore(-1);
        }
    
    }
}
