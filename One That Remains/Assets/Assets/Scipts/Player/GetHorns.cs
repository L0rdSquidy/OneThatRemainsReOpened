using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GetHorns : MonoBehaviour
{
    public GameObject keyPicture;
    public GameObject keyText2;
    public TMP_Text keyText;
    public GameObject PickUpText;

    public GameObject HornMinigame; 
   // private int keys = 0;
    private bool isPlayerInTrigger = false;
    public PlayerDatas data;

    public Minigame mData;

    public PlayerMovementGrappling pmgMovement;

    public PlayerCam pmgcam;
    public SwingingDone swing;
    public getSheetmusic sheet;
    void Start()
    {
        // pmgMovement = GetComponent<PlayerMovementGrappling>();
        // pmgcam = GetComponent<PlayerCam>();
        // swing = GetComponent<SwingingDone>();
        GameObject playerdata = GameObject.Find("PlayerData");
        // data = playerdata.GetComponent<PlayerDatas>();
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

        if (data.keys == 3 && sheet.data == 1)
        {
            // pmgMovement.enabled = false;
            pmgcam.enabled = false;
            swing.enabled = false;  
            HornMinigame.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            
        }

        if(mData.work == 1)
        {
            pmgMovement.enabled = true;
            pmgcam.enabled = true;
            swing.enabled = true;  
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            data.keys = 0;
            HornMinigame.SetActive(false);
            pmgMovement.jumpForce = 30;
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
