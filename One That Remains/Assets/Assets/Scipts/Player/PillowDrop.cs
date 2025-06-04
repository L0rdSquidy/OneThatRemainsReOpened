using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillowDrop : MonoBehaviour
{
    public float cooldowntime = 2f;
    public bool isCooldown = false;
    // Start is called before the first frame update
    [SerializeField] PillowHit droplet;

    public float Destroytime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        // trajectoryHeight = true;
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldowntime);
        isCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Random.value < 0.005 && !isCooldown)
        {
            StartCoroutine(Cooldown());
            PillowHit copyDroplet = Instantiate(droplet);
            copyDroplet.transform.position = transform.position;
            Destroy(copyDroplet, Destroytime);
           
            
        } 
        
    }
}
