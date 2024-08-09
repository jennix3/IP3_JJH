using UnityEngine;

public class TriggerGhost : MonoBehaviour
{
    public GameObject targetObject;  // The object that will disappear

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(targetObject);
        }
    }
}
