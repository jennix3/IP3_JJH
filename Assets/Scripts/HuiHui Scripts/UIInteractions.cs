/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Handles UI interactions such as button clicks, slider changes, and toggle changes.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles UI interactions such as button clicks, slider changes, and toggle changes.
/// </summary>
public class UIInteractions : MonoBehaviour
{
    /// <summary>
    /// Called when a button is clicked.
    /// </summary>
    public void ClickFunction()
    {
        Debug.Log("Button was clicked");
    }

    /// <summary>
    /// Called when the slider value changes.
    /// </summary>
    /// <param name="sliderValue">The new value of the slider.</param>
    public void SliderChange(float sliderValue)
    {
        Debug.Log(sliderValue);
    }

    /// <summary>
    /// Called when the toggle value changes.
    /// </summary>
    /// <param name="toggleValue">The new value of the toggle.</param>
    public void ToggleChange(bool toggleValue)
    {
        Debug.Log(toggleValue);
    }
}
