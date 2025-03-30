using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PillowHit : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent Portalenter;
    private GameObject Player;
    public Vector3 teleport_exit;

    public HP hpScript;

    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            Portalenter.Invoke();
            Player = other.gameObject;
            other.gameObject.SetActive(false);
            StartCoroutine(WaitForTeleport());
            hpScript.AddScore(-1);


        }
    }
    IEnumerator WaitForTeleport() {
        yield return new WaitForSeconds(1f);
        Player.transform.position = teleport_exit;
        Player.SetActive(true);

    }
}

