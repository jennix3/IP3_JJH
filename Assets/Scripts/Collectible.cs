/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public void Collected()
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        // Destroy the attached GameObject
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the collectibles interaction.
    /// Increase the player's score and destroy itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.IncreaseScore(myScore);
        Collected();
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if(collision.gameObject.tag == "Player")
        {
            currentPlayer = collision.gameObject.GetComponent<Player>();
            UpdatePlayerInteractable(currentPlayer);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that
        // stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            RemovePlayerInteractable(currentPlayer);
            currentPlayer = null;
        }
    }


}
