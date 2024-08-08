using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI interactionText; // Reference to your TextMeshPro UI element
    public List<GameObject> collectibleObjects = new List<GameObject>(); // List of collectible objects
    public GameObject door; // Assign the door object in the inspector
    public GameObject keycardObject; // Assign the keycard object in the inspector

    private bool hasCollectedKeycard = false; // Track if the keycard has been collected
    private bool hasCollectedAnyCollectible = false; // Track if any collectible has been collected
    private GameObject currentCollectible; // Reference to the current collectible the player is interacting with

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentCollectible = other.gameObject;
            interactionText.text = "\"E\" to pick up";
            interactionText.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Keycard") && !hasCollectedKeycard)
        {
            interactionText.text = "\"E\" to pick up keycard";
            interactionText.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Door"))
        {
            if (hasCollectedKeycard)
            {
                interactionText.text = "\"E\" to open door";
            }
            else if (hasCollectedAnyCollectible)
            {
                interactionText.text = "wrong keycard cb";
            }
            else
            {
                interactionText.text = "find a key";
            }
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible") || other.CompareTag("Keycard") || other.CompareTag("Door"))
        {
            interactionText.gameObject.SetActive(false);
            currentCollectible = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactionText.gameObject.activeSelf)
            {
                if (interactionText.text.Contains("pick up") && currentCollectible != null)
                {
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
                else if (interactionText.text.Contains("pick up keycard") && keycardObject != null)
                {
                    // Collect the keycard
                    hasCollectedKeycard = true;
                    Destroy(keycardObject);
                    keycardObject = null; // Ensure the reference is cleared
                    interactionText.gameObject.SetActive(false);
                }
                else if (interactionText.text.Contains("open door") && hasCollectedKeycard)
                {
                    // Destroy the door
                    Destroy(door);
                    door = null; // Ensure the reference is cleared
                    interactionText.gameObject.SetActive(false);
                }
            }
        }
    }
}
