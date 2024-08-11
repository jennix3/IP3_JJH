using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages game over events, including displaying text and UI buttons, pausing the game, and disabling game components.
/// </summary>
public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;  // The text component that displays the game over message.
    public TMP_Text additionalText;  // The text component that displays additional information or messages.
    public Button restartButton;  // The button that allows the player to restart the current level.
    public Button backToMenuButton;  // The button that allows the player to go back to the main menu.
    public MonoBehaviour[] componentsToDisable;  // Array of MonoBehaviour components to disable when the game is over.

    void Start()
    {
        // Hide all game over UI elements initially.
        if (gameOverText != null) gameOverText.gameObject.SetActive(false);
        if (additionalText != null) additionalText.gameObject.SetActive(false);
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
    /// Triggers the game over sequence.
    /// </summary>
    public void TriggerGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "You Died";

            if (additionalText != null)
            {
                additionalText.gameObject.SetActive(true);
                additionalText.text = "The students stuck here are looking for replacement... yet you let them replace you. Haiya... you deserve a grade cap.";  // Example text
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
