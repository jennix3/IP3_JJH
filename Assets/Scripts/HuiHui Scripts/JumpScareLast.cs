/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Triggers a jump scare event when the player enters a designated area, followed by ending the game after a short delay.
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Triggers a jump scare event when the player enters a designated area.
/// The jump scare includes an image and a sound, followed by ending the game.
/// </summary>
public class JumpScareLast : MonoBehaviour
{
    /// <summary>
    /// The GameObject that displays the jump scare image.
    /// </summary>
    public GameObject JumpScareImg;

    /// <summary>
    /// The audio source that plays the jump scare sound.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Initializes the script by ensuring the jump scare image is initially hidden.
    /// </summary>
    void Start()
    {
        JumpScareImg.SetActive(false);
    }

    /// <summary>
    /// Triggers the jump scare and starts the process to end the game when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that enters the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JumpScareImg.SetActive(true);
            audioSource.Play();
            StartCoroutine(EndGame());
        }
    }

    /// <summary>
    /// Waits for a specified duration before ending the game.
    /// </summary>
    /// <returns>IEnumerator for coroutine.</returns>
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the Unity editor
#else
        Application.Quit(); // Quit the application in a build
#endif
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Currently not used, but present for potential future updates.
    }
}
