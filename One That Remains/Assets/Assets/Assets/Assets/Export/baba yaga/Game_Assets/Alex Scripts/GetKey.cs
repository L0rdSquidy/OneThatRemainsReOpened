using System.Collections;
using System.Collections.Generic;
using TMPro;
//sing UnityEditor.SearchService;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public GameObject keyPicture;
    public GameObject keyText2;
    public TMP_Text keyText;
    public GameObject PickUpText;
   // private int keys = 0;
    private bool isPlayerInTrigger = false;
    public PlayerDatas2 data;

    void Start()
    {
        GameObject playerdata = GameObject.Find("PlayerData");
        // data = playerdata.GetComponent<PlayerDatas2>();
        keyPicture.SetActive(false);
        keyText2.SetActive(false);
        PickUpText.SetActive(false);

        keyText.GetComponent<TMP_Text>();
        data.keys = 0;
        keyText.text = "" + data.keys;
    }
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed while in trigger");
            this.gameObject.SetActive(false);
            keyPicture.SetActive(true);
            keyText2.SetActive(true);
            AddKeys(1);
            PickUpText.SetActive(false);
        }
    }

    public void AddKeys(int add)
    {
        data.keys += add;
        keyText.text = "" + data.keys;
        Debug.Log(data.keys);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpText.SetActive(false);
            isPlayerInTrigger = false;
        }
    }
}
