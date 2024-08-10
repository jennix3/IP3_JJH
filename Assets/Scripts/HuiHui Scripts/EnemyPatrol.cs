/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Controls enemy patrol behavior within a specified area and handles player collisions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls enemy patrol behavior within a specified area and handles player collisions.
/// </summary>
public class EnemyPatrol : MonoBehaviour
{
    /// <summary>
    /// The NavMeshAgent component attached to the enemy for pathfinding.
    /// </summary>
    public NavMeshAgent agent;

    /// <summary>
    /// The radius of the area within which the enemy will patrol.
    /// </summary>
    public float range;

    /// <summary>
    /// The center point of the area the enemy will patrol around.
    /// </summary>
    public Transform centrePoint;

    /// <summary>
    /// Initializes the NavMeshAgent and sets the default center point if none is specified.
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (centrePoint == null)
        {
            centrePoint = transform; // Default to agent's position if no centrePoint is specified
        }
    }

    /// <summary>
    /// Updates the enemy's patrol behavior, setting a new random destination when the current path is completed.
    /// </summary>
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // Done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) // Pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); // So you can see with gizmos
                agent.SetDestination(point);
                Debug.Log("New destination set: " + point);
            }
            else
            {
                Debug.LogWarning("Failed to find a valid point within the range.");
            }
        }
    }

    /// <summary>
    /// Generates a random point within a sphere around a center point and checks if it is on the NavMesh.
    /// </summary>
    /// <param name="center">The center of the sphere.</param>
    /// <param name="range">The radius of the sphere.</param>
    /// <param name="result">The resulting valid point on the NavMesh.</param>
    /// <returns>True if a valid point is found, otherwise false.</returns>
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; // Random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) // Documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    /// <summary>
    /// Handles collisions with other objects, including the player.
    /// </summary>
    /// <param name="collision">The Collision data associated with the collision event.</param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            // Add health reduction logic here
            Debug.Log("Collided with player.");
        }
    }
}
