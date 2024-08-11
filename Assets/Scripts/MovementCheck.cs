using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public LightManager lightManager; // Reference to the LightManager script
    public GameObject gameOverCanvas; // Reference to your Game Over canvas
    public FirstPersonMovement playerController; // Reference to your first person controller
    public GameOverManager gameOverManager; // Reference to the GameOverManager script

    private bool gameOver = false;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (!gameOver && !lightManager.IsGreen() && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true); // Show the Game Over canvas
        playerController.enabled = false; // Disable the player controller to stop movement
        gameOverManager.TriggerGameOver(); // Call the TriggerGameOver method from GameOverManager
    }
}
