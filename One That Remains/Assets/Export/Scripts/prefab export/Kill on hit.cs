using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using UnityEngine.SceneManagement;
public class Killonhit : MonoBehaviour
{
     public UnityEvent Portalenter;
    private GameObject Player;
    public Vector3 teleport_exit;

    private HP hpScript;

    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        hpScript = FindObjectOfType<HP>();
        
        // FindUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            // if (UI != null)
            // {
            //     UI.SetActive(true);
            // }
            // else
            // {
            //     Debug.LogError("UI GameObject is not assigned and could not be found.");
            // }
            Portalenter.Invoke();
            Player = other.gameObject;
            other.gameObject.SetActive(false);
            StartCoroutine(WaitForTeleport());

            hpScript.AddScore(-3);

        }
    }
    IEnumerator WaitForTeleport() {
        yield return new WaitForSeconds(0.6f);
        Player.transform.position = teleport_exit;
        UI.SetActive (true);
        StartCoroutine(ToDEATH());
        // Player.SetActive(true);
        // if (UI != null)
        // {
        //     UI.SetActive(false);
        // }

    }

    IEnumerator ToDEATH()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_Menu");
    }
}
