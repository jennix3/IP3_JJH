using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public GameObject canvasToShow;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) 
        {
            ShowCanvas();
        }
    }

    private void ShowCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(true);
        }
    }
}

