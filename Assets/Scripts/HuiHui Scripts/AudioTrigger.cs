/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles audio playback when the player enters or exits a trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for playing and stopping audio when the player enters or exits a trigger zone.
/// </summary>
public class AudioTrigger : MonoBehaviour
{
    /// <summary>
    /// The AudioSource component attached to this GameObject.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the AudioSource component.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the audio when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that enters the trigger zone.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Stops the audio and destroys the GameObject when the player exits the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that exits the trigger zone.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
            Destroy(gameObject);
        }
    }
}
