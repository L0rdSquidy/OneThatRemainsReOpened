using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CataPultINtro : MonoBehaviour
{
    public GameObject Bho;
    public GameObject CataPult;

    public GameObject CataPultText;
    public GameObject CataPultInteract;
    public bool Bitha = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")&& Bitha == false)
        {
            // Bho.SetActive(true);
            // CataPult.SetActive(true);
            // CataPultText.SetActive(true);
            StartCoroutine(BlahaiShark());
            

        } 
        if (other.gameObject.CompareTag("Player")&& Bitha == true)
        {
            // Bho.SetActive(true);
            // CataPult.SetActive(true);
            // CataPultText.SetActive(true);
            // StartCoroutine(Horsy());
            CataPultInteract.SetActive(true);

        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CataPultInteract.SetActive(false);
        }
    }

    IEnumerator BlahaiShark()
    {
        Bho.SetActive(true);
        CataPult.SetActive(true);
        CataPultText.SetActive(true);
        yield return new WaitForSeconds(3f);
        CataPultText.SetActive(false);
        Bitha = true;
    }

    
    // IEnumerator Horsy()
    // {
    //     yield return new WaitForSeconds(4f);
    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
