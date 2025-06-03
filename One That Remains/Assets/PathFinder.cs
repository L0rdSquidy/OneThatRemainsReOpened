using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
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
    private List<GameObject> spawnedParticles = new List<GameObject>();
    private Coroutine clearRoutine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // If already showing, clear now
            ClearParticles();

            // Find & set new destination
            TryFindBestQuestPath();
        }
    }

    void TryFindBestQuestPath()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, searchRadius, objectiveLayer);
        float bestCost = Mathf.Infinity;
        Vector3 bestTargetPos = Vector3.zero;

        foreach (var hit in hits)
        {
            NavMeshPath path = new NavMeshPath();
            if (!NavMesh.CalculatePath(transform.position, hit.transform.position,
                                       NavMesh.AllAreas, path) ||
                path.status != NavMeshPathStatus.PathComplete)
                continue;

            float cost = EvaluatePathCost(path);
            if (cost < bestCost)
            {
                bestCost = cost;
                bestTargetPos = hit.transform.position;
            }
        }

        if (bestCost < Mathf.Infinity)
        {
            agent.SetDestination(bestTargetPos);
            // Visualize with particles
            SpawnPathParticles(agent.path);
            // Schedule auto-clear
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
            Vector3 start = corners[i];
            Vector3 end = corners[i + 1];
            float segmentLen = Vector3.Distance(start, end);
            int count = Mathf.CeilToInt(segmentLen / particleSpacing);

            for (int j = 0; j <= count; j++)
            {
                float t = (count > 0) ? (float)j / count : 0f;
                Vector3 pos = Vector3.Lerp(start, end, t);
                var p = Instantiate(particlePrefab, pos, Quaternion.identity);
                spawnedParticles.Add(p);
                // If you want them to self-destruct as well, uncomment:
                // Destroy(p, particleLifetime);
            }
        }
    }

    void ClearParticles()
    {
        if (clearRoutine != null)
        {
            StopCoroutine(clearRoutine);
            clearRoutine = null;
        }

        foreach (var p in spawnedParticles)
            if (p != null) Destroy(p);
        spawnedParticles.Clear();
    }

    IEnumerator AutoClearParticles()
    {
        yield return new WaitForSeconds(particleLifetime);
        ClearParticles();
    }
}
