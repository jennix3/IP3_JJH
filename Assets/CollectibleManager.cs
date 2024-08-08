using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CollectibleManager : MonoBehaviour
{
    public TextMeshProUGUI interactionText; // The text for interaction prompts
    public TextMeshProUGUI countText; // The text for displaying the collectible count
    public TextMeshProUGUI specialMessageText; // The text for the special message
    public GameObject door; // The door to be destroyed

    private GameObject currentCollectible;
    private int collectiblesCollected = 0;
    private int totalCollectibles = 7;
    public float specialMessageDuration = 3f; // Duration to show the special message

    void Start()
    {
        HideInteractionText();
        specialMessageText.gameObject.SetActive(false); // Initially hide the special message
        UpdateCountText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionText.gameObject.activeSelf)
        {
            Collect();
        }
    }

    public void ShowInteractionText(string message)
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = message;
    }

    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    public void SetCurrentCollectible(GameObject collectible)
    {
        currentCollectible = collectible;
    }

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
                StartCoroutine(ShowSpecialMessage("I heard something"));
            }
            else if (collectiblesCollected > totalCollectibles)
            {
                // Ensure the collectible count never exceeds total collectibles
                collectiblesCollected = totalCollectibles;
            }

            HideInteractionText();
        }
    }

    private void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = $"{collectiblesCollected}/{totalCollectibles}";
        }
    }

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






