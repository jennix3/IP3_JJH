using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light pointLight; // Reference to your point light
    public float interval = 2.0f; // Interval for changing light color

    private bool isGreen = true;

    void Start()
    {
        InvokeRepeating("ToggleLight", interval, interval);

        if (pointLight == null)
        {
            Debug.LogError("The pointLight variable is not assigned!");
        }
        else
        {
            Debug.Log("The pointLight variable is assigned correctly.");
        }
    }

    void ToggleLight()
    {
        isGreen = !isGreen;
        pointLight.color = isGreen ? Color.green : Color.red;
    }

    public bool IsGreen()
    {
        return isGreen;
    }
}
