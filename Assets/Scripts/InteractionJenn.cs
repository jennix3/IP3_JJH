/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages interaction with objects of type 'Letter' within a specified distance.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages interaction with objects of type 'Letter' within a specified distance.
/// Displays interaction text when an interactable object is detected and allows interaction using the 'Q' key.
/// </summary>
public class InteractionJenn : MonoBehaviour
{
    /// <summary>
    /// The maximum distance at which interactions can occur.
    /// </summary>
    public float interactionDistance;

    /// <summary>
    /// The GameObject that displays interaction text.
    /// </summary>
    public GameObject interactionText;

    /// <summary>
    /// Layer mask to specify which layers can be interacted with.
    /// </summary>
    public LayerMask interactionLayers;

    /// <summary>
    /// Checks for interactable objects in the specified direction and distance.
    /// Displays interaction text and allows interaction with objects of type 'Letter' when the 'Q' key is pressed.
    /// </summary>
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
        {
            if (hit.collider.gameObject.GetComponent<Letter>())
            {
                interactionText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hit.collider.gameObject.GetComponent<Letter>().openCloseLetter();
                }
            }
            else
            {
                interactionText.SetActive(false);
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
}
