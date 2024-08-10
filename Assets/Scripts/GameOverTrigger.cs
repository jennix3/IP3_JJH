/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles game over events by displaying game over text, additional text, and UI buttons for restarting or returning to the main menu. Disables certain game components and controls game pause/resume.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages game over events, including displaying text and UI buttons, pausing the game, and disabling game components.
/// </summary>
public class GameOverTrigger : MonoBehaviour
{
    /// <summary>
    /// The text component that displays the game over message.
    /// </summary>
    public TMP_Text gameOverText;

    /// <summary>
    /// The text component that displays additional information or messages.
    /// </summary>
    public TMP_Text additionalText;

    /// <summary>
    /// The button that allows the player to restart the current level.
    /// </summary>
    public Button restartButton;

    /// <summary>
    /// The button that allows the player to go back to the main menu.
    /// </summary>
    public Button backToMenuButton;

    /// <summary>
    /// Array of MonoBehaviour components to disable when the game is over.
    /// This can include movement and camera scripts.
    /// </summary>
    public MonoBehaviour[] componentsToDisable;

    /// <summary>
    /// Initializes the script by hiding the game over text, additional text, and buttons, and setting up button listeners.
    /// </summary>
    void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        if (additionalText != null)
        {
            additionalText.gameObject.SetActive(false); // Initially hide the additional text
        }
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartLevel);
        }
        if (backToMenuButton != null)
        {
            backToMenuButton.gameObject.SetActive(false);
            backToMenuButton.onClick.AddListener(BackToMenu);
        }
    }

    /// <summary>
    /// Displays the game over UI and pauses the game when the player collides with the trigger.
    /// </summary>
    /// <param name="other">The Collider that triggered the event.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "You Died";

                if (additionalText != null)
                {
                    additionalText.gameObject.SetActive(true); // Show additional text
                    additionalText.text = "The students stuck here are looking for replacement... yet you let them replace you. Haiya... you deserve a grade cap."; // Example text
                }

                restartButton.gameObject.SetActive(true);
                backToMenuButton.gameObject.SetActive(true);

                // Pause the game
                Time.timeScale = 0f;

                // Disable movement and camera scripts
                foreach (MonoBehaviour component in componentsToDisable)
                {
                    component.enabled = false;
                }

                // Unlock and show the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    /// <summary>
    /// Restarts the current level by reloading the active scene.
    /// </summary>
    void RestartLevel()
    {
        // Unpause the game before restarting
        Time.timeScale = 1f;

        // Re-enable movement and camera scripts
        foreach (MonoBehaviour component in componentsToDisable)
        {
            component.enabled = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Loads the main menu scene and unpauses the game.
    /// </summary>
    void BackToMenu()
    {
        // Unpause the game before going back to the menu
        Time.timeScale = 1f;

        // Load the main menu scene (assuming your main menu scene is named "MainMenu")
        SceneManager.LoadScene("MainMenu");
    }
}
