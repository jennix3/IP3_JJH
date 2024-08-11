/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Handles interaction with collectible items, including showing interaction text and playing sounds.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages interaction with collectible items, including showing interaction text and playing sounds.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// Reference to the CollectibleManager script for managing collectibles.
    /// </summary>
    public GameObject collectibleManager;

    /// <summary>
    /// The sound to play when interacting with the collectible.
    /// </summary>
    public AudioClip interactSound;

    /// <summary>
    /// The AudioSource component used to play the interaction sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the AudioSource component on start.
    /// </summary>
    private void Start()
    {
        // Get or add an AudioSource component to the collectible
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Handles collision with the player. Shows interaction text and sets the current collectible.
    /// Plays the interaction sound if assigned.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CollectibleManager manager = collectibleManager.GetComponent<CollectibleManager>();
            manager.ShowInteractionText("\"E\" to collect");
            manager.SetCurrentCollectible(gameObject);

            // Play the interaction sound
            if (interactSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(interactSound);
            }
        }
    }

    /// <summary>
    /// Handles collision exit with the player. Hides the interaction text.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collectibleManager.GetComponent<CollectibleManager>().HideInteractionText();
        }
    }
}
