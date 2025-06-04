using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    public GameObject MusicOnplay;
    public GameObject MusicOnplayboost;
    public Slider b1;
    public Slider b2;
    public Slider b3;
    public Slider b4;
    public Slider b5;
    public Slider b6;
    public Slider b7;
    public Slider b8;
    public GameObject BAhai;
    public PlayerDatas data;
    public PlayerMovementGrappling pmgMovement;
    public PlayerCam pmgcam;
    public SwingingDone swing;

    public int a1;
    public int a2;
    public int a3;
    public int a4;
    public int a5;
    public int a6;
    public int a7;
    public int a8;
  
    public int work;
    
    public GameObject gameObjec;

     [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    
    [SerializeField] private bool closeTrigger = false;

    public TMP_Text keyText;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.T))
       {
        MusicOnplay.SetActive(true);
        MusicOnplayboost.SetActive(true);
        StartCoroutine(Opendoor());
       }
    }
    public void opendoor()
    {
    if(b1.value == a1 && b2.value == a2 && b3.value == a3 && b4.value == a4 && b5.value == a5 && b6.value == a6 && b7.value == a7 && b8.value == a8)
       {
        Debug.Log("GGGGGGGGGGGGGGGGGGGe");
            MusicOnplay.SetActive(true);
            MusicOnplayboost.SetActive(true);
            StartCoroutine(Opendoor());
       }
    }

    

    IEnumerator Opendoor()
    {
        Debug.Log("HLLLLLLLLLLLLLLLLL");
        yield return new WaitForSecondsRealtime(11f);
        work = 1;
        BAhai.SetActive(true);
        pmgMovement.enabled = true;
        pmgcam.enabled = true;
        swing.enabled = true;  
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        data.keys = 0;
        Debug.Log("Hello there");
        pmgMovement.jumpForce = 30;
        myDoor.Play("door", 0, 0.0f);
        gameObject.SetActive(false);
        data.keys--;
        keyText.text = data.keys.ToString();
        gameObjec.SetActive(false);
    }
}
