/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages collectible behavior, including detecting player interaction and awarding points.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages collectible behavior, including detecting player interaction and awarding points.
/// </summary>
public class Collectibles : MonoBehaviour
{
    /// <summary>
    /// Indicates if the player is within range of the collectible.
    /// </summary>
    private bool playerInRange;

    /// <summary>
    /// Points awarded when the collectible is collected.
    /// </summary>
    public int points = 10;

    /// <summary>
    /// Detects when a collision with the player occurs and sets playerInRange to true.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    /// <summary>
    /// Detects when the collision with the player ends and sets playerInRange to false.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    /// <summary>
    /// Checks if the player is in range and the interaction key is pressed to add points and destroy the collectible.
    /// </summary>
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ScoreManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
