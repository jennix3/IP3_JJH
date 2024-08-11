/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages interactions with a key card object, including showing a message when colliding with the player,
 *              and deactivating the key card and another object when the player presses the "E" key.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages interactions with a key card object, including showing a message when colliding with the player,
/// and deactivating the key card and another object when the player presses the "E" key.
/// </summary>
public class CorrectKeyCard : MonoBehaviour
{
    /// <summary>
    /// Reference to another GameObject to be deactivated along with this key card.
    /// </summary>
    public GameObject otherCube;

    /// <summary>
    /// Reference to the TMP_Text component for displaying messages to the player.
    /// </summary>
    public TextMeshProUGUI messageText;

    /// <summary>
    /// Indicates if the player is currently colliding with the key card.
    /// </summary>
    private bool isCollidingWithPlayer = false;

    /// <summary>
    /// Initializes the message text to be hidden at the start.
    /// </summary>
    void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Handles the collision with the player, showing the message text when the collision occurs.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            if (messageText != null)
            {
                messageText.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Handles the end of collision with the player, hiding the message text if the "E" key is not pressed.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            if (messageText != null && !Input.GetKey(KeyCode.E))
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Checks if the player is colliding with the key card and the "E" key is pressed to deactivate the key card and the other object.
    /// </summary>
    void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.E))
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false);
            }

            gameObject.SetActive(false);

            if (otherCube != null)
            {
                otherCube.SetActive(false);
            }
        }
    }
}
