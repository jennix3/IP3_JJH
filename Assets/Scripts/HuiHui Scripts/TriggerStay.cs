/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Controls the activation and deactivation of a target GameObject when the player enters or exits a trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the activation and deactivation of a target GameObject when the player enters or exits a trigger zone.
/// </summary>
public class TriggerStay : MonoBehaviour
{
    /// <summary>
    /// The GameObject that will be enabled or disabled when the player interacts with the trigger zone.
    /// </summary>
    public GameObject targetGameObject;

    /// <summary>
    /// Initializes the script by ensuring the target GameObject is initially disabled.
    /// </summary>
    void Start()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Enables the target GameObject when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that enters the trigger zone.</param>
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
    /// Disables the target GameObject when the player exits the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that exits the trigger zone.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(false);
            }
        }
    }
}
