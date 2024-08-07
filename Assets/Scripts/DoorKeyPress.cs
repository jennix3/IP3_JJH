using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorKeyPress : MonoBehaviour
{
    [SerializeField] bool playerInRange;
    [SerializeField] bool isdoorOpen;
    [SerializeField] TMP_Text interactText; // Reference to the shared TMP_Text

    Animator anim;
    AudioSource audioSource;
    [SerializeField] AudioClip doorOpenSound;  // Audio for opening the door
    [SerializeField] AudioClip doorCloseSound; // Audio for closing the door

    [SerializeField] float autoCloseDelay = 5f; // Time in seconds before the door closes automatically
    private Coroutine autoCloseCoroutine;

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

    private void OpenDoor()
    {
        if (anim != null)
        {
            anim.SetTrigger("Open");
        }
        isdoorOpen = true;
        if (audioSource != null && doorOpenSound != null)
        {
            audioSource.PlayOneShot(doorOpenSound); // Play open sound
        }

        // Start the auto-close coroutine
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
        }
        autoCloseCoroutine = StartCoroutine(AutoCloseDoor());
    }

    private void CloseDoor()
    {
        if (anim != null)
        {
            anim.SetTrigger("Close");
        }
        isdoorOpen = false;
        if (audioSource != null && doorCloseSound != null)
        {
            audioSource.PlayOneShot(doorCloseSound); // Play close sound
        }

        // Stop the auto-close coroutine
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
        }
    }

    private IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(autoCloseDelay);
        if (isdoorOpen)
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            UpdateInteractText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.SetText(""); // Clear text when player leaves the door
        }
    }

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
