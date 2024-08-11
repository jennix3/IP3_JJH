using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] pointLights; // Array to hold multiple point lights
    public float interval = 2.0f; // Interval for changing light color

    private bool isGreen = true;

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

    void ToggleLight()
    {
        isGreen = !isGreen;
        Color newColor = isGreen ? Color.green : Color.red;

        foreach (Light light in pointLights)
        {
            light.color = newColor;
        }
    }

    public bool IsGreen()
    {
        return isGreen;
    }
}
