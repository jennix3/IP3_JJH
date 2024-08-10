/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages the visibility of the letter UI based on player interaction.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the visibility of the letter UI based on player interaction.
/// </summary>
public class Letter : MonoBehaviour
{
    /// <summary>
    /// The UI GameObject representing the letter.
    /// </summary>
    public GameObject letterUI;

    private bool toggle;

    /// <summary>
    /// The Renderer component for the letter's mesh.
    /// </summary>
    public Renderer letterMesh;

    /// <summary>
    /// Toggles the visibility of the letter UI.
    /// </summary>
    public void openCloseLetter()
    {
        toggle = !toggle;
        letterUI.SetActive(toggle);
    }
}
