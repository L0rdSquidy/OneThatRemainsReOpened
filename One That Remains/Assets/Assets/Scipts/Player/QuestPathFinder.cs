using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;

// [RequireComponent(typeof(NavMeshAgent))]
public class QuestPathFinder : MonoBehaviour
{
	[Header("Search Settings")]
	public float searchRadius = 30f;
	public LayerMask objectiveLayer;

	[Header("Path Cost Weights")]
	public float jumpHeightThreshold = 1f;
	public float jumpPenalty = 5f;
	public float fallHeightThreshold = 2f;
	public float fallPenalty = 3f;
	public float turnAngleWeight = 0.1f;

	[Header("Particle Visualizer")]
	public GameObject particlePrefab;
	public float particleSpacing = 1f;
	public float particleLifetime = 3f;

	private NavMeshAgent agent;
	private PlayerMovementGrappling pmg;
	private List<GameObject> spawnedParticles = new List<GameObject>();
	private Coroutine clearRoutine;
	
	private bool setTime;
	private bool SetActivation;
	private float timeElapsed;

	void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		pmg = GetComponentInChildren<PlayerMovementGrappling>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			agent.enabled = true;
			if (agent.enabled)
			{
				ClearParticles();
				TryFindBestQuestPath();
			}
			pmg.enabled = false;
			SetActivation = true;
		}
		if (SetActivation)
		{
			timeElapsed += Time.deltaTime;
			if (timeElapsed > 0.2f)
			{
				setTime = true;
				timeElapsed = 0;
				ClearParticles();
				TryFindBestQuestPath();
				SetActivation = false;
			}	
		}
		if (setTime)
		{
			timeElapsed += Time.deltaTime;
			if (timeElapsed > 0.2f)
			{
				pmg.enabled = true;
				agent.enabled = false;
				setTime = false;
				timeElapsed = 0;
			}
		}
	}

	void TryFindBestQuestPath()
	{
		Collider[] hits = null;
		hits = Physics.OverlapSphere(transform.position, searchRadius, objectiveLayer);
		float bestCost = Mathf.Infinity;
		Vector3 bestTargetPos = Vector3.zero;
		Debug.Log(hits[0]);
		if (agent.isOnNavMesh == false)
		{
			Debug.LogError("Agent is not on the NavMesh!");
			return;
		}


		foreach (var hit in hits)
		{
			NavMeshPath path;
			path = new NavMeshPath();
			Debug.Log(NavMesh.CalculatePath(transform.position, hit.transform.position, NavMesh.AllAreas, path));
			Debug.Log($"Path status: {path.status} | Corners: {path.corners.Length}");
			if (!NavMesh.CalculatePath(transform.position, hit.transform.position, NavMesh.AllAreas, path))
				{
					Debug.LogWarning("Failed to calculate path to: " + hit.transform.name);
					continue;
				}
				if (path.status != NavMeshPathStatus.PathComplete)
				{
					Debug.LogWarning("Incomplete path to: " + hit.transform.name);
					continue;
				}
			float cost = EvaluatePathCost(path);
			Debug.Log(cost);
			if (cost < bestCost)
			{
				bestCost = cost;
				bestTargetPos = hit.transform.position;
				
				// Debug.Log(hit.transform.position);
			}
		}
		Debug.Log(bestCost);
		if (bestCost < Mathf.Infinity)
		{
			agent.SetDestination(bestTargetPos);
			SpawnPathParticles(agent.path);
			clearRoutine = StartCoroutine(AutoClearParticles());
			
		}
	}

	float EvaluatePathCost(NavMeshPath path)
	{
		float cost = 0f;
		Vector3[] corners = path.corners;

		for (int i = 0; i < corners.Length - 1; i++)
		{
			Vector3 A = corners[i];
			Vector3 B = corners[i + 1];
			float dist = Vector3.Distance(A, B);
			cost += dist;

			// vertical penalty
			float dh = B.y - A.y;
			if (dh > jumpHeightThreshold)      cost += jumpPenalty;
			else if (-dh > fallHeightThreshold) cost += fallPenalty;

			// turn penalty
			if (i > 0)
			{
				Vector3 prevDir = (A - corners[i - 1]).normalized;
				Vector3 currDir = (B - A).normalized;
				float angle = Vector3.Angle(prevDir, currDir);
				cost += angle * turnAngleWeight;
			}
		}

		return cost;
	}

	void SpawnPathParticles(NavMeshPath path)
	{
		Vector3[] corners = path.corners;
		for (int i = 0; i < corners.Length - 1; i++)
		{
			Debug.Log("hey");
			Vector3 start = corners[i];
			Vector3 end = corners[i + 1];
			float segmentLen = Vector3.Distance(start, end);
			int count = Mathf.CeilToInt(segmentLen / particleSpacing);

			for (int j = 0; j <= count; j++)
			{
				Debug.Log("hey");
				float t = (count > 0) ? (float)j / count : 0f;
				Vector3 pos = Vector3.Lerp(start, end, t);
				var p = Instantiate(particlePrefab, pos, Quaternion.identity);
				Debug.DrawRay(pos, Vector3.up, Color.green, 5f);
				// Debug.Log(particleLifetime);
				spawnedParticles.Add(p);
				// Destroy(p, particleLifetime);
			}
		}
		path = null;
	}

	void ClearParticles()
	{
		
		if (clearRoutine != null)
		{
			StopCoroutine(clearRoutine);
			clearRoutine = null;
		}
		
		foreach (var p in spawnedParticles)
			if (p != null) 
			
			{
				Destroy(p);
			}
		spawnedParticles.Clear();
	}

	IEnumerator AutoClearParticles()
	{
		yield return new WaitForSeconds(particleLifetime);
		// Debug.Log("Destroy");
		ClearParticles();
	}
}
