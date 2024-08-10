/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles player interactions with objects in the game, such as opening letters when within a certain distance.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player interactions with objects in the game, such as opening letters when within a certain distance.
/// </summary>
public class Interaction : MonoBehaviour
{
    /// <summary>
    /// The maximum distance at which the player can interact with objects.
    /// </summary>
    public float interactionDistance;

    /// <summary>
    /// The UI text element that indicates an interaction is possible.
    /// </summary>
    public GameObject interactionText;

    /// <summary>
    /// The layers that the player can interact with.
    /// </summary>
    public LayerMask interactionLayers;

    /// <summary>
    /// Updates every frame to check for interactions.
    /// </summary>
    void Update()
    {
        RaycastHit hit;

        // Cast a ray forward from the player's position to detect interactable objects within range.
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
        {
            if (hit.collider.gameObject.GetComponent<Letter>())
            {
                // Show interaction text when the player is close to an interactable object.
                interactionText.SetActive(true);

                // Check for player input to interact with the object.
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hit.collider.gameObject.GetComponent<Letter>().openCloseLetter();
                }
            }
            else
            {
                interactionText.SetActive(false); // Hide interaction text if the object is not interactable.
            }
        }
        else
        {
            interactionText.SetActive(false); // Hide interaction text if no interactable objects are detected.
        }
    }
}
