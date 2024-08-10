/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Continuously scrolls the texture of a material along the Y-axis to create a moving texture effect.
 */

using UnityEngine;

/// <summary>
/// Continuously scrolls the texture of a material along the Y-axis to create a moving texture effect.
/// </summary>
public class MoveTexture : MonoBehaviour
{
    /// <summary>
    /// The speed at which the texture scrolls.
    /// </summary>
    public float scrollSpeed = 0.1f;

    /// <summary>
    /// The Renderer component attached to the GameObject.
    /// </summary>
    private Renderer rend;

    /// <summary>
    /// Initializes the Renderer component.
    /// </summary>
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("Renderer component not found on the GameObject.");
        }
    }

    /// <summary>
    /// Updates the texture offset every frame to create a scrolling effect.
    /// </summary>
    void Update()
    {
        if (rend != null)
        {
            float moveThis = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0, moveThis));
        }
    }
}
