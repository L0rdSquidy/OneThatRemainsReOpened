using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TOh());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TOh()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("house");
    }
}
