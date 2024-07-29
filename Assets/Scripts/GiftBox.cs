using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;
    [SerializeField]
    private AudioClip collectAudio;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
            SpawnCollectible();
            Destroy(gameObject);
        }        
    }



    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
