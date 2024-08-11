/* 
 * Name : Lucky 777
 * Date: 10/08/2024
 * Description: Controls AI behavior including patrolling and chasing the player based on distance and safe zones.
 */

using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls AI behavior including patrolling and chasing the player based on distance and safe zones.
/// </summary>
public class AIController : MonoBehaviour
{
    /// <summary>
    /// Points that the AI patrols between.
    /// </summary>
    public Transform[] patrolPoints;

    /// <summary>
    /// The player's transform used for chasing.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Safe zones where the player can hide.
    /// </summary>
    public Transform[] safeZones;

    /// <summary>
    /// Distance at which the AI starts chasing the player.
    /// </summary>
    public float chaseDistance = 10f;

    /// <summary>
    /// Radius within which a safe zone is considered effective.
    /// </summary>
    public float safeZoneRadius = 5f;

    private NavMeshAgent navMeshAgent;
    private int currentPatrolIndex;
    private bool isChasing;

    /// <summary>
    /// Initializes the AI controller and sets the first patrol point.
    /// </summary>
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    /// <summary>
    /// Updates the AI's behavior based on player distance and patrol points.
    /// </summary>
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

    /// <summary>
    /// Starts chasing the player.
    /// </summary>
    void ChasePlayer()
    {
        isChasing = true;
        navMeshAgent.SetDestination(player.position);
    }

    /// <summary>
    /// Moves the AI to the next patrol point.
    /// </summary>
    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    /// <summary>
    /// Checks if the player is in any of the safe zones.
    /// </summary>
    /// <returns>True if the player is in a safe zone, otherwise false.</returns>
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
