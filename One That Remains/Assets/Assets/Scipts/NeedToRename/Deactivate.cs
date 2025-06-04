using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(DeactivateBitch());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeactivateBitch()
    {
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }
}
