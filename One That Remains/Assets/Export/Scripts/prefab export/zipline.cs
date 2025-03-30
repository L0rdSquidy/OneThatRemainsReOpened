using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    [SerializeField] private Zipline TargetZip;
    [SerializeField] private float Zipspeed = 5f;
    [SerializeField] private float Zipscale = 0.2f;

    [SerializeField] private float arrivaltreshold = 0.4f;
    [SerializeField] private LineRenderer cable;
    public Transform ZiplineTransform;
    public float ZippingTime = 2f;
    private bool Zipping = false;
    private GameObject localZip;
    // Start is called before the first frame update
    private void Awake() 
    {
        cable.SetPosition(0, ZiplineTransform.position);
        cable.SetPosition(1, TargetZip.ZiplineTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!Zipping || localZip == null) return;

        localZip.GetComponent<Rigidbody>().AddForce((TargetZip.ZiplineTransform.position - ZiplineTransform.position).normalized * Zipspeed * Time.deltaTime, ForceMode.Acceleration); 

        if (Vector3.Distance(localZip.transform.position, TargetZip.transform.position) <= arrivaltreshold)
        {
            StartCoroutine(Waittoreset());
        } 
    }

    public void startzipping(GameObject player)
    {
        if(Zipping) return;

        localZip = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        localZip.transform.position = ZiplineTransform.position;
        localZip.transform.localScale = new Vector3(Zipscale, Zipscale, Zipscale);
        localZip.AddComponent<Rigidbody>().useGravity = false;
        localZip.GetComponent<Collider>().isTrigger = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.parent = localZip.transform;
        Zipping = true;
        
    }

    IEnumerator Waittoreset()
    {
        yield return new WaitForSeconds(ZippingTime);
        resetZipline();
    }
    private void resetZipline()
    {
        if(!Zipping) return;
        
        GameObject player = localZip.transform.GetChild(0).gameObject;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.parent = null;
        Destroy(localZip);
        localZip = null;
        Zipping = false;
        Debug.Log("bubu");
    }
}
