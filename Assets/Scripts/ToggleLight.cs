/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Toggles a light source on and off with sound effects when the player presses a key.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Toggles a light source on and off with sound effects when the player presses a key.
/// </summary>
public class ToggleLight : MonoBehaviour
{
    /// <summary>
    /// The GameObject representing the light source.
    /// </summary>
    public GameObject LightSource;

    /// <summary>
    /// Sound effect for turning the flashlight on.
    /// </summary>
    public AudioClip toggleOnAudio;

    /// <summary>
    /// Sound effect for turning the flashlight off.
    /// </summary>
    public AudioClip toggleOffAudio;

    private bool isOn = false;

    /// <summary>
    /// Updates the light source state based on user input.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isOn)
            {
                Invoke("LightOn", 0.3f);
            }
            else
            {
                Invoke("LightOff", 0.3f);
            }
        }
    }

    /// <summary>
    /// Turns the light source on and plays the corresponding sound effect.
    /// </summary>
    void LightOn()
    {
        LightSource.SetActive(true);
        isOn = true;

        if (toggleOnAudio != null)
        {
            AudioSource.PlayClipAtPoint(toggleOnAudio, transform.position, 1f);
        }
    }

    /// <summary>
    /// Turns the light source off and plays the corresponding sound effect.
    /// </summary>
    void LightOff()
    {
        LightSource.SetActive(false);
        isOn = false;

        if (toggleOffAudio != null)
        {
            AudioSource.PlayClipAtPoint(toggleOffAudio, transform.position, 1f);
        }
    }
}
