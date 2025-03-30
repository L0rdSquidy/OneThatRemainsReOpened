using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAgrappleSpot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pop;

    public GameObject spot;
    private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player"))
        {
            if (spot.active){
            pop.SetActive(true);
            StartCoroutine(popop());
            }
        }
        
     }

     IEnumerator popop()
     {
        yield return new WaitForSeconds(5);
        pop.SetActive(false);
     }
}
