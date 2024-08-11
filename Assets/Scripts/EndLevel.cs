/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Displays a message on collision with the player and transitions to a new scene when a key is pressed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Displays a message on the canvas when the player collides with the trigger and loads a new scene when the player presses a specific key.
/// </summary>
public class ShowMessageOnCollision : MonoBehaviour
{
    /// <summary>
    /// The Canvas that displays the message.
    /// </summary>
    public Canvas messageCanvas;

    /// <summary>
    /// The TextMeshPro component that shows the message text.
    /// </summary>
    public TMP_Text messageText;

    /// <summary>
    /// Indicates whether the message is currently shown.
    /// </summary>
    private bool isMessageShown = false;

    /// <summary>
    /// Initializes the message canvas and hides it at the start.
    /// </summary>
    void Start()
    {
        messageCanvas.enabled = false;
    }

    /// <summary>
    /// Shows the message when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The Collider that enters the trigger zone.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageCanvas.enabled = true;
            messageText.enabled = true;
            isMessageShown = true;
        }
    }

    /// <summary>
    /// Checks if the message is shown and listens for a key press to load a new scene.
    /// </summary>
    void Update()
    {
        if (isMessageShown && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(8);
        }
    }
}
