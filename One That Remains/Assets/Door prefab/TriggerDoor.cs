using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    

    [SerializeField] private Animator my2Door = null;

    [SerializeField] private bool openTrigger = false;
   
    [SerializeField] private bool closeTrigger = false;

   public bool ISPlayerInTrigger = false;

   public bool Playerlock;

    public float waittime = 5f;

   
    private void Start()
    {
        // GameObject playerdata = GameObject.Find("PlayerData");
        // data = playerdata.GetComponent<PlayerDatas2>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
                    ISPlayerInTrigger = true;
                   

        }
    }

    void Update()
    {
        
        if (ISPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (openTrigger)
                {
                my2Door.Play("DOORPOOP", 0, 0.0f);
                closeTrigger = true;
                openTrigger = false;
                
                } else if(closeTrigger)
                {
                my2Door.Play("DOORCLOSEPOOP", 0, 0.0f);
                closeTrigger = false;
                openTrigger = true;
                }
        } else if (ISPlayerInTrigger && Input.GetKeyDown(KeyCode.F) && !Playerlock)
        {
            Invoke("lockdoor", waittime);
            
        } else if (ISPlayerInTrigger && Input.GetKeyDown(KeyCode.F) && Playerlock)
        {
            Invoke("unlockdoor", waittime);
        }
    }
    public void lockdoor()
    {
        closeTrigger = false;
        openTrigger = false;
        Playerlock = true;
    }
    public void unlockdoor()
    {
        closeTrigger = true;
        openTrigger = true;
        Playerlock = false;
    }
}
