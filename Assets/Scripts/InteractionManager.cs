/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages player interactions with collectibles, keycards, and doors, including UI updates and item collection.
 */

using UnityEngine;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// Manages interactions with collectible objects, keycards, and doors.
/// Handles UI updates and item collection processes.
/// </summary>
public class InteractionManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshPro UI element for interaction prompts.
    /// </summary>
    public TextMeshProUGUI interactionText;

    /// <summary>
    /// List of collectible objects in the scene.
    /// </summary>
    public List<GameObject> collectibleObjects = new List<GameObject>();

    /// <summary>
    /// The door object that can be unlocked.
    /// </summary>
    public GameObject door;

    /// <summary>
    /// The keycard object that can be collected.
    /// </summary>
    public GameObject keycardObject;

    /// <summary>
    /// Audio clip played when collecting items.
    /// </summary>
    public AudioClip collectAudio;

    private bool hasCollectedKeycard = false; // Tracks if the keycard has been collected
    private bool hasCollectedAnyCollectible = false; // Tracks if any collectible has been collected
    private GameObject currentCollectible; // Reference to the current collectible the player is interacting with

    /// <summary>
    /// Handles interactions when entering a trigger collider.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentCollectible = other.gameObject;
            interactionText.text = "Press \"E\" to pick up.";
            interactionText.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Keycard") && !hasCollectedKeycard)
        {
            interactionText.text = "Press \"E\" to pick up.";
            interactionText.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Door"))
        {
            if (hasCollectedKeycard)
            {
                interactionText.text = "Press \"E\" to unlock door";
            }
            else if (hasCollectedAnyCollectible)
            {
                interactionText.text = "Wrong key... the notes will guide you";
            }
            else
            {
                interactionText.text = "Something is needed to unlock...";
            }
            interactionText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Hides the interaction text when exiting a trigger collider.
    /// </summary>
    /// <param name="other">The collider that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible") || other.CompareTag("Keycard") || other.CompareTag("Door"))
        {
            interactionText.gameObject.SetActive(false);
            currentCollectible = null;
        }
    }

    /// <summary>
    /// Checks for player input to interact with objects.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionText.gameObject.activeSelf)
        {
            if (interactionText.text.Contains("pick up") && currentCollectible != null)
            {
                // Play the sound effect when collecting an item
                if (collectAudio != null)
                {
                    AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
                }

                // Remove the collectible from the list before destroying it
                if (collectibleObjects.Contains(currentCollectible))
                {
                    collectibleObjects.Remove(currentCollectible);
                }

                // Collect the current item
                Destroy(currentCollectible);
                hasCollectedAnyCollectible = true; // Set to true when any collectible is collected
                currentCollectible = null;
                interactionText.gameObject.SetActive(false);
            }
            else if (interactionText.text.Contains("pick up") && keycardObject != null)
            {
                // Play the sound effect when collecting the keycard
                if (collectAudio != null)
                {
                    AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
                }

                // Collect the keycard
                hasCollectedKeycard = true;
                Destroy(keycardObject);
                keycardObject = null; // Ensure the reference is cleared
                interactionText.gameObject.SetActive(false);
            }
            else if (interactionText.text.Contains("unlock door") && hasCollectedKeycard)
            {
                // Destroy the door
                Destroy(door);
                door = null; // Ensure the reference is cleared
                interactionText.gameObject.SetActive(false);
            }
        }
    }
}
