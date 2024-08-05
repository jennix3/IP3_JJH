using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("Renderer component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rend != null)
        {
            float moveThis = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0, moveThis));
        }
    }
}
