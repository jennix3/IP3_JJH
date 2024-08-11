/*
 * Date: 10/08/2024
 * Description: Manages the patrol behavior of an AI character using a NavMeshAgent. The AI moves to random points within a specified range and patrols the area.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls the patrol behavior of an AI character using NavMeshAgent.
/// The AI moves to random points within a specified range and patrols the area.
/// </summary>
public class Patrol : MonoBehaviour
{
    /// <summary>
    /// Reference to the NavMeshAgent component for navigation.
    /// </summary>
    private NavMeshAgent agent;

    /// <summary>
    /// Layer mask to specify which layers are considered ground.
    /// </summary>
    [SerializeField] private LayerMask groundLayer;

    /// <summary>
    /// Range within which patrol points are randomly chosen.
    /// </summary>
    [SerializeField] private float range = 10f;

    /// <summary>
    /// The current destination point for the patrol.
    /// </summary>
    private Vector3 destPoint;

    /// <summary>
    /// Flag indicating whether a patrol point has been set.
    /// </summary>
    private bool walkpointSet;

    /// <summary>
    /// Initializes the NavMeshAgent and sets the initial patrol destination.
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SearchForDest();
    }

    /// <summary>
    /// Updates the patrol behavior each frame.
    /// </summary>
    void Update()
    {
        GhostPatrol();
    }

    /// <summary>
    /// Manages the patrol behavior by setting a new destination when needed and moving towards it.
    /// </summary>
    private void GhostPatrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 1f) walkpointSet = false;
    }

    /// <summary>
    /// Searches for a new patrol destination point within the specified range.
    /// </summary>
    private void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, 100f, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
