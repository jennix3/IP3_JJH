/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages the activation and deactivation of a target GameObject when the player enters or exits a trigger collider.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the activation and deactivation of a target GameObject when the player enters or exits a trigger collider.
/// </summary>
public class Trigger : MonoBehaviour
{
    /// <summary>
    /// The GameObject to enable or disable when the player interacts with the trigger collider.
    /// </summary>
    public GameObject targetGameObject;

    /// <summary>
    /// Ensures the target GameObject is initially disabled.
    /// </summary>
    void Start()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The collider that entered the trigger collider.</param>
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

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The collider that exited the trigger collider.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
