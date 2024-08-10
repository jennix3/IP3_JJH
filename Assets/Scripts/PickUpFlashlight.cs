/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages the pickup of a flashlight, including showing/hiding UI elements and playing sound effects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the pickup of a flashlight, including showing/hiding UI elements and playing sound effects.
/// </summary>
public class PickUpFlashlight : MonoBehaviour
{
    /// <summary>
    /// The flashlight GameObject that will be activated when picked up.
    /// </summary>
    public GameObject FlashLightOnPlayer;

    /// <summary>
    /// The Canvas that shows "Press E to pick up" when the player is near.
    /// </summary>
    public GameObject pickUpCanvas;

    /// <summary>
    /// The AudioClip that plays when the flashlight is picked up.
    /// </summary>
    public AudioClip collectAudio;

    private void Start()
    {
        FlashLightOnPlayer.SetActive(false);

        if (pickUpCanvas != null)
        {
            pickUpCanvas.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickUpCanvas != null)
            {
                pickUpCanvas.SetActive(true);
            }

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                FlashLightOnPlayer.SetActive(true);

                if (collectAudio != null)
                {
                    AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
                }

                if (pickUpCanvas != null)
                {
                    pickUpCanvas.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && pickUpCanvas != null)
        {
            pickUpCanvas.SetActive(false);
        }
    }
}
