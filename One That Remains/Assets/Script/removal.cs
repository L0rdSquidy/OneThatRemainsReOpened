using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removal : MonoBehaviour
{
    public GameObject bleh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(bhehe());
    }

    IEnumerator bhehe()
    {
        
         bleh.SetActive(false);
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
    }
}
