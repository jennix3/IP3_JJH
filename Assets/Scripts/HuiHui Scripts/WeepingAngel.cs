/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: This script controls the behavior of the Weeping Angel AI, including its movement and interactions with the player.
 */

using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Manages the behavior of the Weeping Angel AI, including movement and player detection.
/// </summary>
public class WeepingAngel : MonoBehaviour
{
    /// <summary>
    /// Reference to the NavMeshAgent component used for pathfinding.
    /// </summary>
    public NavMeshAgent agent;

    /// <summary>
    /// Reference to the player's Transform.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Reference to the player's Camera.
    /// </summary>
    public Camera playerCamera;

    /// <summary>
    /// Speed of the AI when it moves.
    /// </summary>
    public float aiSpeed = 3.5f;

    /// <summary>
    /// Range within which the AI starts chasing the player.
    /// </summary>
    public float chaseRange = 10f;

    private Renderer aiRenderer;

    /// <summary>
    /// Initializes the Weeping Angel by setting up references and verifying components.
    /// </summary>
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (player == null || playerCamera == null)
        {
            Debug.LogError("Player or Player Camera is not assigned.");
        }

        aiRenderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Updates the AI behavior each frame based on the player's position and visibility.
    /// </summary>
    void Update()
    {
        if (agent == null || player == null || playerCamera == null || aiRenderer == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < chaseRange && !IsInPlayerView())
        {
            ChasePlayer();
        }
        else
        {
            StopMoving();
        }
    }

    /// <summary>
    /// Determines if the AI is within the player's view frustum.
    /// </summary>
    /// <returns>True if the AI is within the player's view, false otherwise.</returns>
    bool IsInPlayerView()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCamera);
        return GeometryUtility.TestPlanesAABB(planes, aiRenderer.bounds);
    }

    /// <summary>
    /// Moves the AI towards the player.
    /// </summary>
    void ChasePlayer()
    {
        agent.speed = aiSpeed;
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    /// <summary>
    /// Stops the AI's movement.
    /// </summary>
    void StopMoving()
    {
        agent.speed = 0;
        agent.isStopped = true;
    }
}
