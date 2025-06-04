using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
// using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider StaminaBar;

    private float StaminaMax = 5000;
    private float CurrentStamina;

    public static Stamina instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public PlayerMovementGrappling enemyTank;

    public float cooldowntime = 1f;
    private bool isCooldown = false;

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldowntime);
        isCooldown = false;
    }


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentStamina =  StaminaMax;
        StaminaBar.maxValue = StaminaMax;
        StaminaBar.value = StaminaMax;

    }

    public void UseStamina(int amount)
    {
        if (CurrentStamina - amount >= 0){
            CurrentStamina -= amount;
            StaminaBar.value = CurrentStamina;

            StartCoroutine(RegenStamina());
        }else{
            Debug.Log("te weinig stamina");
        }
    }

    public float StaminaDeplete()
    {
        return StaminaBar.value;
    }

    public void update()
    {
        if (StaminaBar.value < 1)
        {
            StaminaBar.value = 0;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        // Debug.Log(CurrentStamina);
        // Debug.Log(StaminaMax);
        // Debug.Log(enemyTank);
        while (CurrentStamina < StaminaMax && enemyTank.returnSpeed() == 0f && !isCooldown)
        {   
            CurrentStamina += StaminaMax / 10000;
            Debug.Log("stam max" + StaminaMax);
            Debug.Log("regenerating" + CurrentStamina);

            StaminaBar.value = CurrentStamina;
            yield return regenTick;
        }
    }
    // Update is called once per frame
    
}
