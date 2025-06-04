using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToMain());
    }

    IEnumerator ToMain()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Main_Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
