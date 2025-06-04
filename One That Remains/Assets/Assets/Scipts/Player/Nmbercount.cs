using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nmbercount : MonoBehaviour
{
    public TMP_Text tMP_Text;
    public Slider slider;

    private float Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = slider.value;
        

    }

    // Update is called once per frame
    private void FixedUpdate() {
        tMP_Text.text = "" + Count;
    }
    
}
