/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Handles game over logic when the player moves while the light is not green.
 */

using UnityEngine;

/// <summary>
/// Handles game over logic when the player moves while the light is not green.
/// </summary>
public class MovementCheck : MonoBehaviour
{
    /// <summary>
    /// Reference to the LightManager script to check the light color.
    /// </summary>
    public LightManager lightManager;

    /// <summary>
    /// Reference to the Game Over canvas to be displayed when the game is over.
    /// </summary>
    public GameObject gameOverCanvas;

    /// <summary>
    /// Reference to the first person controller to be disabled on game over.
    /// </summary>
    public FirstPersonMovement playerController;

    /// <summary>
    /// Reference to the GameOverManager script to trigger game over actions.
    /// </summary>
    public GameOverManager gameOverManager;

    /// <summary>
    /// Indicates if the game is over.
    /// </summary>
    private bool gameOver = false;

    /// <summary>
    /// Initializes the game over canvas to be hidden at the start.
    /// </summary>
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    /// <summary>
    /// Checks if the game should be over based on light color and player movement.
    /// </summary>
    void Update()
    {
        if (!gameOver && !lightManager.IsGreen() && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            GameOver();
        }
    }

    /// <summary>
    /// Triggers the game over state by showing the Game Over canvas, disabling the player controller,
    /// and calling the TriggerGameOver method from GameOverManager.
    /// </summary>
    void GameOver()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true); // Show the Game Over canvas
        playerController.enabled = false; // Disable the player controller to stop movement
        gameOverManager.TriggerGameOver(); // Call the TriggerGameOver method from GameOverManager
    }
}
