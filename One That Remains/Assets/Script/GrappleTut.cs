using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTut : MonoBehaviour
{
    public GameObject Tut;
    public GameObject Grapple;
    // Start is called before the first frame update
    void Start()
    {
        Tut.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.5f;
            Tut.SetActive(true);
            StartCoroutine(Blehe());
        }

    }

    IEnumerator Blehe()
    {
        new WaitForSeconds(1f);
        Grapple.SetActive(true);
        new WaitForSeconds(2f);
        Tut.SetActive(false);
       yield return  new WaitForSeconds(3f);
        Time.timeScale = 1;
        Grapple.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
