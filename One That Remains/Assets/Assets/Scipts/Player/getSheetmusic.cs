using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class getSheetmusic : MonoBehaviour
{
    public GameObject keyPicture;
    public GameObject keyText2;
    public TMP_Text keyText;
    public GameObject PickUpText;

    public GameObject HornMinigame; 
   // private int keys = 0;
    private bool isPlayerInTrigger = false;
    public float data = 0;

    public Minigame mData;

    public PlayerMovementGrappling pmgMovement;

    public PlayerCam pmgcam;
    public SwingingDone swing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed while in trigger");
            this.gameObject.SetActive(false);
            keyPicture.SetActive(true);
            keyText2.SetActive(true);
            data += 1;
            PickUpText.SetActive(false);
        }
    }
    // public void AddKeys(int add)
    // {
    //     data.keys += add;
    //     keyText.text = "" + data.keys;
    //     Debug.Log(data.keys);
    // }

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
