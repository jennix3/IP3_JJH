using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private AudioSource openAudio;

    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    bool locked = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Store the current player
            currentPlayer = other.gameObject.GetComponent<Player>();

            // Update the player interactable to be this door.
            UpdatePlayerInteractable(currentPlayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the "Player" tag
        // and currentPlayer is not null
        if (currentPlayer != null && other.CompareTag("Player"))
        {
            // Remove the player Interactable
            RemovePlayerInteractable(currentPlayer);

            // Set the current Player to null
            currentPlayer = null;
        }
    }

    /// <summary>
    /// Handles the door's interaction
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the door</param>
    public override void Interact(Player thePlayer)
    {
        // Call the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Call the OpenDoor() function
        OpenDoor();
    }

    /// <summary>
    /// Handles the door opening 
    /// </summary>
    public void OpenDoor()
    {
        // Door should open only when it is not locked
        // and not already opened.
        if (!locked && !opened)
        {
            // Cannot directly modify the transform rotation.
            // transform.eulerAngles.y += 90f;

            // Create a new Vector3 and store the current rotation.
            Vector3 newRotation = transform.eulerAngles;

            // Add 90 degrees to the y axis rotation
            newRotation.y += 90f;

            // Assign the new rotation to the transform
            transform.eulerAngles = newRotation;

            // Set the opened bool to true
            opened = true;
            openAudio.Play();
        }
    }

    /// <summary>
    /// Sets the lock status of the door.
    /// </summary>
    /// <param name="lockStatus">The lock status of the door</param>
    public void SetLock(bool lockStatus)
    {
        // Assign the lockStatus value to the locked bool.
        locked = lockStatus;
    }
}
