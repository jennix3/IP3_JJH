using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpScare : MonoBehaviour
{
    public GameObject JumpScareImg; public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        JumpScareImg.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            JumpScareImg.SetActive(true);
            audioSource.Play(); StartCoroutine(DisableImg());
        }
    }
    IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(4);
        JumpScareImg.SetActive(false); Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }
}