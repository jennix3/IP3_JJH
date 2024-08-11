using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectibleManager; // Reference to the CollectibleManager
    public AudioClip interactSound; // The sound to play on interaction

    private AudioSource audioSource;

    private void Start()
    {
        // Get or add an AudioSource component to the collectible
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collectibleManager.GetComponent<CollectibleManager>().ShowInteractionText("\"E\" to collect");
            collectibleManager.GetComponent<CollectibleManager>().SetCurrentCollectible(gameObject);

            // Play the interaction sound
            if (interactSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(interactSound);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collectibleManager.GetComponent<CollectibleManager>().HideInteractionText();
        }
    }
}
