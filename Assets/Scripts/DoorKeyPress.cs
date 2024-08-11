/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages door interactions including opening and closing with sound effects, 
 *              handles automatic door closing, and updates interaction text.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages door interactions including opening and closing with sound effects, 
/// handles automatic door closing, and updates interaction text.
/// </summary>
public class DoorKeyPress : MonoBehaviour
{
    /// <summary>
    /// Indicates if the player is within range of the door.
    /// </summary>
    [SerializeField] bool playerInRange;

    /// <summary>
    /// Indicates if the door is currently open.
    /// </summary>
    [SerializeField] bool isdoorOpen;

    /// <summary>
    /// Reference to the TMP_Text component for interaction prompts.
    /// </summary>
    [SerializeField] TMP_Text interactText;

    private Animator anim;
    private AudioSource audioSource;

    /// <summary>
    /// Audio clip played when the door opens.
    /// </summary>
    [SerializeField] AudioClip doorOpenSound;

    /// <summary>
    /// Audio clip played when the door closes.
    /// </summary>
    [SerializeField] AudioClip doorCloseSound;

    /// <summary>
    /// Time in seconds before the door closes automatically.
    /// </summary>
    [SerializeField] float autoCloseDelay = 5f;

    private Coroutine autoCloseCoroutine;

    /// <summary>
    /// Initializes the interact text and checks for required components.
    /// </summary>
    private void Awake()
    {
        if (interactText != null)
        {
            interactText.SetText("");
        }
        else
        {
            Debug.LogWarning("Interact Text is not assigned!");
        }
    }

    /// <summary>
    /// Sets up the Animator and AudioSource components.
    /// </summary>
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (anim == null)
        {
            Debug.LogError("Animator component is missing!");
        }
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    /// <summary>
    /// Updates interaction text and handles door open/close based on player input.
    /// </summary>
    private void Update()
    {
        if (playerInRange)
        {
            // Show interaction text based on door state
            interactText.SetText(isdoorOpen ? "\"E\" to Close" : "\"E\" to Open");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isdoorOpen)
                {
                    CloseDoor();
                }
                else
                {
                    OpenDoor();
                }
            }
        }
    }

    /// <summary>
    /// Opens the door, plays the open sound, and starts the auto-close coroutine.
    /// </summary>
    private void OpenDoor()
    {
        if (anim != null)
        {
            anim.SetTrigger("Open");
        }
        isdoorOpen = true;
        if (audioSource != null && doorOpenSound != null)
        {
            audioSource.PlayOneShot(doorOpenSound);
        }

        // Start the auto-close coroutine
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
        }
        autoCloseCoroutine = StartCoroutine(AutoCloseDoor());
    }

    /// <summary>
    /// Closes the door, plays the close sound, and stops the auto-close coroutine.
    /// </summary>
    private void CloseDoor()
    {
        if (anim != null)
        {
            anim.SetTrigger("Close");
        }
        isdoorOpen = false;
        if (audioSource != null && doorCloseSound != null)
        {
            audioSource.PlayOneShot(doorCloseSound);
        }

        // Stop the auto-close coroutine
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
        }
    }

    /// <summary>
    /// Automatically closes the door after a delay.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    private IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(autoCloseDelay);
        if (isdoorOpen)
        {
            CloseDoor();
        }
    }

    /// <summary>
    /// Sets playerInRange to true and updates interaction text when the player enters the trigger.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            UpdateInteractText();
        }
    }

    /// <summary>
    /// Sets playerInRange to false and clears interaction text when the player exits the trigger.
    /// </summary>
    /// <param name="other">The collider that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.SetText(""); // Clear text when player leaves the door
        }
    }

    /// <summary>
    /// Updates the interaction text based on the door state.
    /// </summary>
    private void UpdateInteractText()
    {
        if (isdoorOpen)
        {
            interactText.SetText("\"E\" to Close");
        }
        else
        {
            interactText.SetText("\"E\" to Open");
        }
    }
}
