/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Controls enemy behavior, including patrolling, chasing the player, and attacking when in range.
 */

using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls the enemy's patrolling, chasing, and attacking behaviors based on the player's proximity and field of view.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The player's transform that the enemy will chase.
    /// </summary>
    public Transform target;

    /// <summary>
    /// The NavMeshAgent component attached to the enemy for pathfinding.
    /// </summary>
    public NavMeshAgent myAgent;

    /// <summary>
    /// Array of patrol points that the enemy will move between.
    /// </summary>
    public Transform[] patrolPoints;

    /// <summary>
    /// The distance within which the enemy starts chasing the player.
    /// </summary>
    public float chaseRange = 10f;

    /// <summary>
    /// The distance within which the enemy attacks the player.
    /// </summary>
    public float attackRange = 2f;

    /// <summary>
    /// The speed at which the enemy patrols.
    /// </summary>
    public float patrolSpeed = 2f;

    /// <summary>
    /// The speed at which the enemy chases the player.
    /// </summary>
    public float chaseSpeed = 4f;

    /// <summary>
    /// The field of view angle within which the enemy can detect the player.
    /// </summary>
    public float fieldOfViewAngle = 60f;

    /// <summary>
    /// The amount of damage dealt to the player when the enemy attacks.
    /// </summary>
    public float damageAmount = 10f;

    /// <summary>
    /// The index of the current patrol point the enemy is moving towards.
    /// </summary>
    private int currentPatrolIndex;

    /// <summary>
    /// Flag to indicate if the enemy is currently chasing the player.
    /// </summary>
    private bool isChasing;

    /// <summary>
    /// Initializes the enemy's patrol behavior.
    /// </summary>
    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            myAgent = GetComponent<NavMeshAgent>();
            currentPatrolIndex = 0;
            myAgent.speed = patrolSpeed;
            myAgent.destination = patrolPoints[currentPatrolIndex].position;
        }
        else
        {
            Debug.LogError("No patrol points assigned to the enemy.");
        }
    }

    /// <summary>
    /// Updates the enemy's behavior each frame, switching between patrolling and chasing based on the player's position.
    /// </summary>
    void Update()
    {
        if (target == null || myAgent == null)
        {
            Debug.LogError("Target or NavMeshAgent is not assigned.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(target.position, transform.position);

        if (distanceToPlayer < chaseRange && IsPlayerInFieldOfView())
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    /// <summary>
    /// Handles the enemy's patrol behavior, moving between predefined patrol points.
    /// </summary>
    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        myAgent.speed = patrolSpeed;

        if (!myAgent.pathPending && myAgent.remainingDistance < myAgent.stoppingDistance)
        {
            if (myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                myAgent.destination = patrolPoints[currentPatrolIndex].position;
            }
        }
    }

    /// <summary>
    /// Handles the enemy's chase behavior, pursuing the player when within chase range.
    /// </summary>
    void ChasePlayer()
    {
        myAgent.speed = chaseSpeed;

        if (Vector3.Distance(target.position, transform.position) > attackRange)
        {
            myAgent.destination = target.position;
        }
        else
        {
            AttackPlayer();
        }
    }

    /// <summary>
    /// Attacks the player when within attack range.
    /// </summary>
    void AttackPlayer()
    {
        Debug.Log("Attacking Player");
    }

    /// <summary>
    /// Determines if the player is within the enemy's field of view.
    /// </summary>
    /// <returns>True if the player is within the field of view, otherwise false.</returns>
    bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = (target.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        return angleToPlayer <= fieldOfViewAngle / 2f;
    }
}
