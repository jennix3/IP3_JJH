using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectKeyCard : MonoBehaviour
{
    public GameObject otherCube;
    public TextMeshProUGUI messageText;

    private bool isCollidingWithPlayer = false;

    void Start()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            if (messageText != null)
            {
                messageText.gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            if (messageText != null && !Input.GetKey(KeyCode.E))
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.E))
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false);
            }

            gameObject.SetActive(false);

            if (otherCube != null)
            {
                otherCube.SetActive(false);
            }
        }
    }
}
