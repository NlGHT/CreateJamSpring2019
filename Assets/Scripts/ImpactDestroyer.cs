using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroyer : MonoBehaviour
{
    public float impactMagnitudeThreshold = 50;
    private Controller player;
    public ParticleSystem explosionEffect;
    public GameObject explosionAudioCarrier;
    //public AudioSource explosionAudio;

    private static bool isQuitting = false;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Controller>();
        //explosionAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerPart")
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            Vector3 forward = transform.TransformDirection(Vector3.right);
            Vector3 toOther = collision.transform.position - transform.position;
            float dot = Vector3.Dot(forward, toOther);
            Debug.Log(gameObject.name + " | " + collision.relativeVelocity.magnitude + " | " + dot);
            if (collision.relativeVelocity.magnitude >= impactMagnitudeThreshold)
            {
                if (dot > 0)
                {
                    //Debug.Log("I wreck it!");
                    collision.gameObject.GetComponent<ImpactDestroyer>().Boom();
                }
            }
            else
            {
                //Debug.Log("Weak!");
            }
        }
        else if (collision.relativeVelocity.magnitude > impactMagnitudeThreshold)
        {
            //Debug.Log("Oops!");
            Boom();
        }

    }

    public void Boom()
    {
        //Send message to controller that player is dead
        //Controller should then detach surviving engines
        if (player != null)
        {
            player.Death();
        }

        //PlayClipAtPoint(explosionAudio.clip, explosionAudio.transform.position);

        //This part should then explode
        Destroy(gameObject);
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(explosionAudioCarrier, transform.position, transform.rotation);

            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
