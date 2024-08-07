using UnityEngine;
using UnityEngine.UI; // Use this for the Image component

public class MovementCheck : MonoBehaviour
{
    public LightManager lightManager; // Reference to the LightManager script
    public Image gameOverImage; // Reference to your Game Over image
    public FirstPersonMovement playerController; // Reference to your first person controller

    private bool gameOver = false;

    void Start()
    {
        gameOverImage.gameObject.SetActive(false);
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
        gameOverImage.gameObject.SetActive(true); // Show the Game Over image
        playerController.enabled = false; // Disable the player controller to stop movement
    }
}
