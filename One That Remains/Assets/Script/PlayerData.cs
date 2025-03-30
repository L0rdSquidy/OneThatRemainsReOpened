using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatas : MonoBehaviour
{
    public int keys;

    private PlayerMovementGrappling pmgMovement;
    public GameObject buhbuh;
    public GameObject buhbuh2;
    public GameObject buhbuh3;
    public GameObject buhbuh4;

    // public PillowDrop beheh1;
    // public PillowDrop beheh2;
    // public PillowDrop beheh3;

    // Start is called before the first frame update
    void Start()
    {
        pmgMovement = GetComponent<PlayerMovementGrappling>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            keys = 3;
        }

        if(keys == 1)
        {
            buhbuh.SetActive(true);
        } 
        if(keys == 2)
        {
            buhbuh4.SetActive(true);
            buhbuh.SetActive(false);
            buhbuh2.SetActive(true);
        } 
        if(keys == 3)
        {
            buhbuh.SetActive(false);
            buhbuh2.SetActive(false);
            buhbuh3.SetActive(true);
        }
    }
}
