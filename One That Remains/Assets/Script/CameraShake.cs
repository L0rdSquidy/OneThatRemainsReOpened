using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance; 
    public bool meheh = true;
    public Transform cameraPosition;
    public void Awake() => instance = this;

    public void OnShake(float duration, float strength)
    {
        meheh = false;
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
        new WaitForSeconds(duration);
        meheh = true;
    }

    public static void Shake(float duration, float strength) => instance.OnShake(duration, strength);

    private void Update() 
    {
        if (meheh)
        {
            transform.position = cameraPosition.position;
        }
    }
}
