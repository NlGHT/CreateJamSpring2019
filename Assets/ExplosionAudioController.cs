using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudioController : MonoBehaviour
{
    private AudioSource explosionSound;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("AWake");
        explosionSound = gameObject.GetComponent<AudioSource>();
        explosionSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!explosionSound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
