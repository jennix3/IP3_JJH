using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectTrigger : MonoBehaviour
{
    public GameObject staticObject;
    public GameObject movingObject;

    private void Start()
    {
        // Ensure the moving object is initially inactive
        movingObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(staticObject);
            movingObject.SetActive(true);
        }
    }
}



