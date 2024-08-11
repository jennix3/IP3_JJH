/*
 * Date: 10/08/2024
 * Description: Moves an object between specified patrol points in a loop.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves an object between defined patrol points in a loop.
/// </summary>
public class WalkAround : MonoBehaviour
{
    /// <summary>
    /// Array of patrol points the object will move between.
    /// </summary>
    public Transform[] patrolPoints;

    /// <summary>
    /// Index of the current target patrol point.
    /// </summary>
    public int targetPoint;

    /// <summary>
    /// Speed at which the object moves towards the patrol points.
    /// </summary>
    public float speed;

    /// <summary>
    /// Initializes the starting target point.
    /// </summary>
    void Start()
    {
        targetPoint = 0;
    }

    /// <summary>
    /// Updates the object's position to move towards the current patrol point.
    /// </summary>
    void Update()
    {
        MoveTowardsTarget();
        CheckIfAtTarget();
    }

    /// <summary>
    /// Moves the object towards the current target patrol point.
    /// </summary>
    void MoveTowardsTarget()
    {
        if (patrolPoints.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Checks if the object has reached the current target point and updates the target point if necessary.
    /// </summary>
    void CheckIfAtTarget()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetPoint();
        }
    }

    /// <summary>
    /// Increases the target point index and wraps around if necessary.
    /// </summary>
    void IncreaseTargetPoint()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
