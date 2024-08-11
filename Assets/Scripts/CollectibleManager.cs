/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages the collection of items, updates collectible count, shows interaction and special messages, and handles the destruction of a door when all collectibles are collected.
 */

using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the collection of items, updates collectible count, shows interaction and special messages,
/// and handles the destruction of a door when all collectibles are collected.
/// </summary>
public class CollectibleManager : MonoBehaviour
{
    /// <summary>
    /// The text for interaction prompts.
    /// </summary>
    public TextMeshProUGUI interactionText;

    /// <summary>
    /// The text for displaying the collectible count.
    /// </summary>
    public TextMeshProUGUI countText;

    /// <summary>
    /// The text for the special message.
    /// </summary>
    public TextMeshProUGUI specialMessageText;

    /// <summary>
    /// The door to be destroyed when all collectibles are collected.
    /// </summary>
    public GameObject door;

    private GameObject currentCollectible;
    private int collectiblesCollected = 0;
    private int totalCollectibles = 7;

    /// <summary>
    /// Duration to show the special message.
    /// </summary>
    public float specialMessageDuration = 3f;

    /// <summary>
    /// Initializes the collectible manager by hiding the interaction text and special message,
    /// and updating the collectible count display.
    /// </summary>
    void Start()
    {
        HideInteractionText();
        specialMessageText.gameObject.SetActive(false);
        UpdateCountText();
    }

    /// <summary>
    /// Checks for player input to collect the current collectible if interaction text is active.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionText.gameObject.activeSelf)
        {
            Collect();
        }
    }

    /// <summary>
    /// Shows interaction text with a specified message.
    /// </summary>
    /// <param name="message">The message to display in the interaction text.</param>
    public void ShowInteractionText(string message)
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = message;
    }

    /// <summary>
    /// Hides the interaction text.
    /// </summary>
    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the current collectible game object.
    /// </summary>
    /// <param name="collectible">The collectible game object.</param>
    public void SetCurrentCollectible(GameObject collectible)
    {
        currentCollectible = collectible;
    }

    /// <summary>
    /// Collects the current collectible, updates the collectible count, and handles the special message
    /// and door destruction if all collectibles are collected.
    /// </summary>
    private void Collect()
    {
        if (currentCollectible != null)
        {
            Destroy(currentCollectible);
            collectiblesCollected++;
            UpdateCountText();

            if (collectiblesCollected == totalCollectibles)
            {
                if (door != null)
                {
                    Destroy(door);
                }
                StartCoroutine(ShowSpecialMessage("Something opened"));
            }
            else if (collectiblesCollected > totalCollectibles)
            {
                // Ensure the collectible count never exceeds total collectibles
                collectiblesCollected = totalCollectibles;
            }

            HideInteractionText();
        }
    }

    /// <summary>
    /// Updates the count text to display the number of collectibles collected and the total number of collectibles.
    /// </summary>
    private void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = $"{collectiblesCollected}/{totalCollectibles} Talisman collected";
        }
    }

    /// <summary>
    /// Shows a special message for a specified duration.
    /// </summary>
    /// <param name="message">The special message to display.</param>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    private IEnumerator ShowSpecialMessage(string message)
    {
        if (specialMessageText != null)
        {
            specialMessageText.gameObject.SetActive(true);
            specialMessageText.text = message;
            yield return new WaitForSeconds(specialMessageDuration);
            specialMessageText.gameObject.SetActive(false);
        }
    }
}
