using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject targetGameObject;  // The GameObject to enable/disable

    void Start()
    {
        // Ensure the targetGameObject is initially disabled
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
