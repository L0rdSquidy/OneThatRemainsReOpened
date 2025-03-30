using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutsceneTut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(Play());

       if (Input.GetKeyDown(KeyCode.RightArrow))
       {
            SceneManager.LoadScene("forest");
       }
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(72.9f);
        SceneManager.LoadScene("forest");

    }
}
