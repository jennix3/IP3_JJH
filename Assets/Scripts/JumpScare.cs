/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Triggers a jump scare by displaying an image and playing a sound when the player enters the trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Triggers a jump scare by displaying an image and playing a sound when the player enters the trigger zone.
/// </summary>
public class JumpScare : MonoBehaviour
{
    /// <summary>
    /// The GameObject representing the jump scare image.
    /// </summary>
    public GameObject JumpScareImg;

    /// <summary>
    /// The AudioSource component for playing the jump scare sound.
    /// </summary>
    public AudioSource audioSource;

    private void Start()
    {
        JumpScareImg.SetActive(false);
    }

    /// <summary>
    /// Activates the jump scare image and plays the sound when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JumpScareImg.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableImg());
        }
    }

    /// <summary>
    /// Disables the jump scare image after a delay and destroys the GameObject.
    /// </summary>
    /// <returns>An enumerator for coroutine handling.</returns>
    private IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(1);
        JumpScareImg.SetActive(false);
        Destroy(gameObject);
    }
}
