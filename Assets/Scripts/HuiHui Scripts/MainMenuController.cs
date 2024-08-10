/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Controls the behavior of the main menu, ensuring the cursor is visible and unlocked.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of the main menu, ensuring the cursor is visible and unlocked.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        // Make the cursor visible and unlock it
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
