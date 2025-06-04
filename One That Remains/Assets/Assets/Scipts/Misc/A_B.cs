using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class A_B : MonoBehaviour
{
    [SerializeField] Vector3 differencefactor;
    [SerializeField] GameObject A;
    [SerializeField] GameObject B;
    
    [SerializeField] float distance;


    Vector3 diraction;

    public GameObject Muheheheh;

    public float Wait = 3;

    [SerializeField] float  speed = 10;
    bool AtoB = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = A.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Muheheheh.SetActive(true);
        StartCoroutine(StartRunning());
    }

    IEnumerator StartRunning()
    {
        yield return new WaitForSeconds(Wait);

        if (AtoB)
        {
            differencefactor = B.transform.position - transform.position;
        } else {
            differencefactor = A.transform.position - transform.position;
        }
         
        distance = differencefactor.magnitude;
        diraction = differencefactor.normalized;

        transform.position += diraction * speed * Time.deltaTime;
        if (distance < speed*Time.deltaTime)
        {
            AtoB = !AtoB;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed += 1;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed -= 1;
        }
    }
}
