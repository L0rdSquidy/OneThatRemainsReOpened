using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
	// private TMP_Text scoreField;
	private int hp = 3;
	
	private int Hitcounter;

	[SerializeField] private GameObject player;

	[SerializeField] private Vector3 teleport_exit;

	[SerializeField] private GameObject UI;

	[SerializeField] private GameObject Heart1;

	[SerializeField] private GameObject Heart2;

	[SerializeField] private GameObject Heart3;

	[SerializeField] private GameObject HeartGameover;

	[SerializeField] private PlayerMovementGrappling pmgMovement;

	[SerializeField] private PlayerCam pmgcam;

	public int getHp(){
		return hp;
	}

	public int returnHitcounter()
	{
		return Hitcounter;
	}
	public void AddScore(int add) {
		
		hp += add;
		// scoreField.text = "" + hp;
		Hitcounter -= add;
		UI.SetActive(true);
		StartCoroutine(HitCounterWait());
	}

	IEnumerator HitCounterWait()
	{
		yield return new WaitForSeconds(1f);
		player.SetActive(true);
		Hitcounter = 0;
		UI.SetActive(false);
		player.transform.position = teleport_exit;
	}

	public void setHp(int value)
	{
		hp = value;
	}
	// Update is called once per frame
	void Update()
	{
		if (hp >= 3)
		{
			Heart3.SetActive(true);
			Heart2.SetActive(true);    
			Heart1.SetActive(true);
		}
		else if(hp >= 2)
		{
			Heart3.SetActive(false);
		}else if(hp >= 1)
		{
			Heart3.SetActive(false);
			Heart2.SetActive(false);
		}else
		{
			Heart3.SetActive(false);
			Heart2.SetActive(false);    
			Heart1.SetActive(false);
			HeartGameover.SetActive(true);
			pmgMovement.enabled = false;
			pmgcam.enabled = false;
			StartCoroutine(bloh());
		}
	}

	IEnumerator bloh()
	{
		yield return new WaitForSecondsRealtime(4f);
		SceneManager.LoadScene("Main_Menu");
		
	}
}
