using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform player;
    public Transform[] safeZones;
    public float chaseDistance = 10f;
    public float safeZoneRadius = 5f;

    private NavMeshAgent navMeshAgent;
    private int currentPatrolIndex;
    private bool isChasing;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= chaseDistance && !IsPlayerInAnySafeZone())
        {
            ChasePlayer();
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                GoToNextPatrolPoint();
            }
            else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                GoToNextPatrolPoint();
            }
        }
    }

    void ChasePlayer()
    {
        isChasing = true;
        navMeshAgent.SetDestination(player.position);
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    bool IsPlayerInAnySafeZone()
    {
        foreach (Transform safeZone in safeZones)
        {
            float distanceToSafeZone = Vector3.Distance(player.position, safeZone.position);
            if (distanceToSafeZone <= safeZoneRadius)
            {
                return true;
            }
        }
        return false;
    }
}
