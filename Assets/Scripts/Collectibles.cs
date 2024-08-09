using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private bool playerInRange;
    public int points = 10; 

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ScoreManager.instance.AddScore(points); 
            Destroy(gameObject); 
        }
    }
}



