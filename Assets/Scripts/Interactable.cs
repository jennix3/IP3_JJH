using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectibleManager; // Reference to the CollectibleManager

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collectibleManager.GetComponent<CollectibleManager>().ShowInteractionText("Press E to collect");
            collectibleManager.GetComponent<CollectibleManager>().SetCurrentCollectible(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collectibleManager.GetComponent<CollectibleManager>().HideInteractionText();
        }
    }
}


