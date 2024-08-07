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
            if (isdoorOpen) // door open == true
            {
                interactText.SetText("\"E\" to Close");
            }
            else
            {
                interactText.SetText("\"E\" to Open");
            }
        }
        else
        {
            interactText.SetText("");
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (isdoorOpen)
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
            }
            else
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
