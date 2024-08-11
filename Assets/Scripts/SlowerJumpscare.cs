/*
 * Date: 10/08/2024
 * Description: Manages the display of a jump scare image and audio when the player enters a trigger zone. The image is deactivated after 4 seconds and the game object is destroyed.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the display of a jump scare image and plays a sound when the player enters the trigger zone.
/// </summary>
public class SlowerJumpscare : MonoBehaviour
{
    /// <summary>
    /// The jump scare image that will be displayed.
    /// </summary>
    public GameObject JumpScareImg;

    /// <summary>
    /// The audio source that will play the jump scare sound.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Initializes the script by hiding the jump scare image at the start.
    /// </summary>
    void Start()
    {
        JumpScareImg.SetActive(false);
    }

    /// <summary>
    /// Activates the jump scare image and plays the sound when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider of the object that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JumpScareImg.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableImg());
        }
    }

    /// <summary>
    /// Disables the jump scare image after 4 seconds and destroys the game object.
    /// </summary>
    /// <returns>An IEnumerator for the coroutine.</returns>
    IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(4);
        JumpScareImg.SetActive(false);
        Destroy(gameObject);
    }

    void Update()
    {
    }
}
