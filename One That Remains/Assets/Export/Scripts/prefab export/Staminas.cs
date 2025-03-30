using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
// using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Staminas : MonoBehaviour
{
    public PlayerMovementGrappling pmg;
    public Slider StaminaBar;

    public float StaminaMax = 5000;
    private float CurrentStamina;

    public static Staminas instance;

    private WaitForSeconds regenTick = new WaitForSeconds(2f);

    // public EnemyTank enemyTank;

    public float cooldowntime = 3f;
    private bool isCooldown = false;

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldowntime);
        isCooldown = false;
    }


    public void Awake() 
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
        yield return new WaitForSeconds(10);
        // Debug.Log(CurrentStamina);
        // Debug.Log(StaminaMax);
        // Debug.Log(enemyTank);
        while (CurrentStamina < StaminaMax && !isCooldown && pmg.returnSpeed() == pmg.walkSpeed || pmg.returnSpeed() == 0)
        {   
            CurrentStamina += StaminaMax / 5000;
             StaminaBar.value = CurrentStamina;
            yield return regenTick;
            Debug.Log("stam max" + StaminaMax);
            Debug.Log("regenerating" + CurrentStamina);
            
           

           
        }
    }
    // Update is called once per frame
    
}
