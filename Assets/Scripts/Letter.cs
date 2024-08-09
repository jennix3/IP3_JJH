using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;
    public Renderer letterMesh;

    public void openCloseLetter()
    {
        toggle = !toggle;
        if(toggle == false)
        {
            letterUI.SetActive(false);
            letterMesh.enabled = true;
        }
        if(toggle == true)
        {
            letterUI.SetActive(true);
            letterMesh.enabled = false;
        }
    }
}
