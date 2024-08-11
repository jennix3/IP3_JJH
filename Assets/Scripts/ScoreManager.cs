/*
 * Date: 10/08/2024
 * Description: Manages and displays the player's score using a singleton pattern.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the player's score and updates the score display.
/// Implements a singleton pattern to ensure only one instance exists.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// The singleton instance of the ScoreManager.
    /// </summary>
    public static ScoreManager instance;

    /// <summary>
    /// Reference to the TMP_Text component for displaying the score.
    /// </summary>
    public TMP_Text scoreText;

    /// <summary>
    /// The current score of the player.
    /// </summary>
    private int score = 0;

    /// <summary>
    /// Ensures only one instance of ScoreManager exists.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Initializes the score display.
    /// </summary>
    void Start()
    {
        UpdateScoreText();
    }

    /// <summary>
    /// Adds points to the player's score and updates the display.
    /// </summary>
    /// <param name="points">The number of points to add to the score.</param>
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    /// <summary>
    /// Updates the score display.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
