/*
 * Name: Lucky 777
 * Date: 10/08/2024
 * Description: Manages multiple point lights, toggling their colors between green and red at regular intervals.
 */

using UnityEngine;

/// <summary>
/// Manages multiple point lights, toggling their colors between green and red at regular intervals.
/// </summary>
public class LightManager : MonoBehaviour
{
    /// <summary>
    /// Array to hold multiple point lights to be managed.
    /// </summary>
    public Light[] pointLights;

    /// <summary>
    /// Interval for changing the light color in seconds.
    /// </summary>
    public float interval = 2.0f;

    /// <summary>
    /// Indicates if the current light color is green.
    /// </summary>
    private bool isGreen = true;

    /// <summary>
    /// Initializes the light manager by setting up the light color toggle.
    /// </summary>
    void Start()
    {
        if (pointLights == null || pointLights.Length == 0)
        {
            Debug.LogError("The pointLights array is not assigned or is empty!");
            return;
        }

        InvokeRepeating("ToggleLight", interval, interval);

        Debug.Log("The pointLights array is assigned correctly.");
    }

    /// <summary>
    /// Toggles the light color between green and red.
    /// </summary>
    void ToggleLight()
    {
        isGreen = !isGreen;
        Color newColor = isGreen ? Color.green : Color.red;

        foreach (Light light in pointLights)
        {
            light.color = newColor;
        }
    }

    /// <summary>
    /// Checks if the current light color is green.
    /// </summary>
    /// <returns>True if the light color is green; otherwise, false.</returns>
    public bool IsGreen()
    {
        return isGreen;
    }
}
