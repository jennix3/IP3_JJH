/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Base class for objects that can be interacted with by the player. Provides a virtual method for interaction.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for objects that can be interacted with by the player.
/// </summary>
public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Called when the player interacts with this object.
    /// This method can be overridden by derived classes to provide specific interaction behavior.
    /// </summary>
    /// <param name="thePlayer">The player interacting with the object.</param>
    public virtual void Interact(Player thePlayer)
    {
        Debug.Log(gameObject.name + " was interacted with.");
    }
}
