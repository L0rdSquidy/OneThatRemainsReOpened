using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemover : MonoBehaviour
{
	[SerializeField] ParticleSystem part;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (part.isStopped)
		{
			Destroy(gameObject);
		}
	}
}
