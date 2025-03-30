using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tocutscene : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Cutscene2");
        }
     }
}
