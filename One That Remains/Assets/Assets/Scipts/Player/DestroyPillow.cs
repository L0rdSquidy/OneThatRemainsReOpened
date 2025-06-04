        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyPillow : MonoBehaviour
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
        Debug.Log(hpScript);
        // FindUI();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 6f);
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

            hpScript.AddScore(-1);

        }
    }
    IEnumerator WaitForTeleport() {
        yield return new WaitForSeconds(0.6f);
        Player.transform.position = teleport_exit;
        Player.SetActive(true);
        // if (UI != null)
        // {
        //     UI.SetActive(false);
        // }

    }

    void FindUI()
    {
        // if (UI == null)
        // {
        //     UI = GameObject.Find("Panel"); // Replace "Panel" with the name of your UI GameObject
        //     if (UI == null)
        //     {
        //         Debug.LogWarning("GameObject.Find failed to find the UI. Trying FindObjectOfType.");
        //         UI = FindObjectOfType<RectTransform>()?.gameObject;
        //         if (UI == null)
        //         {
        //             Debug.LogError("FindObjectOfType also failed to find the UI GameObject.");
        //         }
        //         else
        //         {
        //             Debug.Log("UI GameObject found using FindObjectOfType.");
        //         }
        //     }
        //     else
        //     {
        //         Debug.Log("UI GameObject found using GameObject.Find.");
        //     }
            // Alternatively, you can find by tag:
            // UI = GameObject.FindWithTag("YourUITag"); // Replace "YourUITag" with the tag of your UI GameObject
        }

    }

    // void OnEnable()
    // {
    //     FindUI();
    // }

