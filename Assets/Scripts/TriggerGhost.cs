/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles the destruction of a target object when the player enters a trigger collider.
 */

using UnityEngine;

/// <summary>
/// Handles the destruction of a target object when the player enters a trigger collider.
/// </summary>
public class TriggerGhost : MonoBehaviour
{
    /// <summary>
    /// The object that will disappear when the player triggers the collider.
    /// </summary>
    public GameObject targetObject;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The collider that entered the trigger collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(targetObject);
        }
    }
}
