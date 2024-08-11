/*
 * Date: 10/08/2024
 * Description: Displays a canvas when the player enters a trigger zone.
 * Name: Lucky 777
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays a specified canvas when the player enters the trigger zone.
/// </summary>
public class ShowCanvasOnTrigger : MonoBehaviour
{
    /// <summary>
    /// The canvas to be shown when the player triggers the collider.
    /// </summary>
    public GameObject canvasToShow;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The collider of the object that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowCanvas();
        }
    }

    /// <summary>
    /// Activates the canvas assigned to <see cref="canvasToShow"/>.
    /// </summary>
    private void ShowCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(true);
        }
    }
}
