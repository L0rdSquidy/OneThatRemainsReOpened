using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    public GameObject mapUI;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapUI.SetActive(!mapUI.activeSelf);
        }
    }
}
