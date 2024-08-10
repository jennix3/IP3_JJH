/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Controls player interactions with interactable objects in the game world.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls player interactions with interactable objects in the game world.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// The current interactable object that the player can interact with.
    /// </summary>
    private Interactable currentInteractable;

    /// <summary>
    /// The player's camera transform.
    /// </summary>
    [SerializeField]
    private Transform playerCamera;

    /// <summary>
    /// The distance from the player at which interaction with objects is allowed.
    /// </summary>
    [SerializeField]
    private float interactionDistance;

    /// <summary>
    /// The UI text used to display interaction prompts.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI interactionText;

    private void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentInteractable = null;
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            currentInteractable = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called when the player interacts with an object.
    /// </summary>
    public void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this);
        }
    }
}
