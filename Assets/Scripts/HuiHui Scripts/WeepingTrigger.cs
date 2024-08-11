/*
 * Date: 10/08/2024
 * Description: Activates a specified GameObject when the player enters a trigger zone.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activates a specified GameObject when the player enters a trigger zone.
/// </summary>
public class WeepingTrigger : MonoBehaviour
{
    /// <summary>
    /// The GameObject to be activated when the player enters the trigger zone.
    /// </summary>
    public GameObject targetGameObject;

    /// <summary>
    /// Initializes the script by ensuring the target GameObject is initially inactive.
    /// </summary>
    void Start()
    {
        // Ensure the targetGameObject is initially disabled
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Activates the target GameObject when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider of the object that entered the trigger zone.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(true);
            }
        }
    }
}
