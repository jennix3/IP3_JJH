using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverTrigger : MonoBehaviour
{
    public TMP_Text gameOverText;
    public Button restartButton; public MonoBehaviour[] componentsToDisable; // Array to hold movement and camera scripts
    void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartLevel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true); gameOverText.text = "Game Over";
                restartButton.gameObject.SetActive(true);
                // Pause the game                Time.timeScale = 0f;
                // Disable movement and camera scripts
                foreach (MonoBehaviour component in componentsToDisable)
                {
                    component.enabled = false;
                }
                // Unlock and show the cursor
                Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
            }
        }
    }
    void RestartLevel()
    {
        // Unpause the game before restarting        Time.timeScale = 1f;
        // Re-enable movement and camera scripts
        foreach (MonoBehaviour component in componentsToDisable)
        {
            component.enabled = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}