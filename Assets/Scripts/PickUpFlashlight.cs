using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject FlashLightOnPlayer;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Press E to pick up");

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                FlashLightOnPlayer.SetActive(true);
            }
        }
    }
}
