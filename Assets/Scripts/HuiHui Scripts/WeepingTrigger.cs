using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingTrigger : MonoBehaviour
{
    public GameObject targetGameObject;  // The GameObject to enable

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
}
