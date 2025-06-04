using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
	

	[SerializeField] private Animator my2Door = null;

	[SerializeField] private bool openTrigger = false;
   
	[SerializeField] private bool closeTrigger = false;

   public bool ISPlayerInTrigger = false;

   public bool Playerlock;

	public float waittime = 5f;


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			
			ISPlayerInTrigger = true;
		}
	}

	void Update()
	{
		
		if (ISPlayerInTrigger)
		{
			if (openTrigger)
				{
				my2Door.Play("Dooropen", 0, 0.0f);
				closeTrigger = true;
				openTrigger = false;
				
				} 
		}
	}
}
