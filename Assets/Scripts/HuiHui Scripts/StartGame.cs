/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages starting the game scene and quitting the application.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages starting the game scene and quitting the application.
/// </summary>
public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Called when the play button is clicked to start the game scene asynchronously.
    /// </summary>
    public void PlayGame()
    {
        Debug.Log("Start button clicked. Attempting to load game scene...");
        SceneManager.LoadSceneAsync(1).completed += OnSceneLoaded;
    }

    /// <summary>
    /// Callback function called when the game scene has finished loading.
    /// </summary>
    /// <param name="asyncOp">The async operation for loading the scene.</param>
    private void OnSceneLoaded(AsyncOperation asyncOp)
    {
        Debug.Log("Game scene loaded.");

        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Called when the quit button is clicked to exit the application.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Exiting game...");
        Application.Quit();
    }
}
