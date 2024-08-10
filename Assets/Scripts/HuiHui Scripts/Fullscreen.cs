/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Toggles between fullscreen and windowed mode when called.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the toggling between fullscreen and windowed mode.
/// </summary>
public class Fullscreen : MonoBehaviour
{
    /// <summary>
    /// Toggles between fullscreen and windowed mode.
    /// </summary>
    public void Change()
    {
        // Toggle the fullscreen mode
        Screen.fullScreen = !Screen.fullScreen;

        // Print a message indicating the screen mode has changed
        Debug.Log("Changed screen mode");
    }
}
