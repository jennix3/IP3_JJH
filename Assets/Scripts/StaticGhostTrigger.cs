/*
 * Date: 10/08/2024
 * Description: Handles the interaction between a static object and a moving object when the player enters the trigger zone.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the activation of a moving object and destruction of a static object when the player enters a trigger zone.
/// </summary>
public class StaticObjectTrigger : MonoBehaviour
{
    /// <summary>
    /// The static object that will be destroyed when the player enters the trigger zone.
    /// </summary>
    public GameObject staticObject;

    /// <summary>
    /// The moving object that will be activated when the player enters the trigger zone.
    /// </summary>
    public GameObject movingObject;

    /// <summary>
    /// Initializes the script by ensuring the moving object is initially inactive.
    /// </summary>
    private void Start()
    {
        movingObject.SetActive(false);
    }

    /// <summary>
    /// Handles the trigger event when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider of the object that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(staticObject);
            movingObject.SetActive(true);
        }
    }
}
