/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles scene transitions when the player enters a specified trigger.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles scene transitions when the player enters a specified trigger.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// The index of the scene to load when the player enters the trigger.
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The collider that entered the trigger collider.</param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
