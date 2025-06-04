using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicTune : MonoBehaviour
{
    private AudioSource source;

   
    public Slider MuscTune;

    public GameObject red;
    public GameObject green;
    public GameObject blue;

    public float Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = MuscTune.value;
       
    }

    // Update is called once per frame
    public void AddMusic()
    {
        if (MuscTune.value >= 2){
        MuscTune.value += 1;
        Count = MuscTune.value;
        

        }
    }

    public void RemoveMusic()
    {
        if(MuscTune.value > 2)
        {
            MuscTune.value -= 1;
        Count = MuscTune.value;
           
        }
        
    }

    void Update()
    {
        if (Count == 2)
        {
            
            red.SetActive(true);
            green.SetActive(false);
            blue.SetActive(false);
        }else if(Count == 3)
        {

            red.SetActive(false);
            green.SetActive(false);
            blue.SetActive(true);
        }else if(Count == 4)
        {

            red.SetActive(false);
            green.SetActive(true);
            blue.SetActive(false);
        }
    }
}
