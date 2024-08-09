using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerJumpscare : MonoBehaviour
{
    public GameObject JumpScareImg;
    public AudioSource audioSource;

    void Start()
    {
        JumpScareImg.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JumpScareImg.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableImg());
        }
    }

    IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(4);
        JumpScareImg.SetActive(false);
        Destroy(gameObject);
    }

    void Update()
    {
    }
}
