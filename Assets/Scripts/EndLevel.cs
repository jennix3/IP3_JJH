using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ShowMessageOnCollision : MonoBehaviour
{
    public Canvas messageCanvas; 
    public TMP_Text messageText; 
    

    private bool isMessageShown = false;

    void Start()
    {
        messageCanvas.enabled = false; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            messageCanvas.enabled = true;
            messageText.enabled = true;
            isMessageShown = true;
        }
    }

    void Update()
    {
        if (isMessageShown && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);
        }
    }

}
