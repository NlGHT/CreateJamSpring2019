using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    // Audio stuff
    //public AudioClip[] engineSounds;
    public AudioSource[] engineSoundSources;
    private AudioSource idleSound;
    private AudioSource idleToFullSound;
    private AudioSource fullSound;
    private AudioSource fullToIdleSound;
    private bool accelerating;
    private float timeAccelerating;
    private const float AudioFadeFactor = 0.5f;

    public bool isActive = false;

    // Rotation variables
    public float torque = 10;
    public float rotateStrength;
    public string input = "p1Rotation";
    public KeyCode leftRotate = KeyCode.A;
    public KeyCode rightRotate = KeyCode.D;

    // Movement variables
    public KeyCode forward = KeyCode.W;
    public KeyCode reverse = KeyCode.S;
    public KeyCode boost = KeyCode.Q;
    public float move = 10;
    float OriginalMove;
    public float boostPower = 50;

    Rigidbody rigid; // rigid body for character
    BoostEffectController bec; //Boost effect
    public float respawnTime = 3f;
    public PlayerSpawnPoint spawner;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        idleSound = engineSoundSources[0];
        idleToFullSound = engineSoundSources[1];
        fullSound = engineSoundSources[2];
        fullToIdleSound = engineSoundSources[3];
        OriginalMove = move;

        fullSound.volume = 0;
        fullSound.Play();
        //idleSound.volume = 0;
        idleSound.Play();

        bec = GetComponent<BoostEffectController>();
    }


    void Update()
    {
<<<<<<< HEAD
        if (isActive)
=======
        float deltaTime = Time.deltaTime;
        //Debug.Log(deltaTime);


        rotateStrength = Input.GetAxis(input);
        if (rotateStrength != 0)
        {
            // Rotate the player
            rigid.AddTorque(transform.forward * torque * (rotateStrength * 0.4f));
        }

        // Movement keys, adds force in desired direction
        if (Input.GetKey(forward))
>>>>>>> 94c81290a65f955cb83b4a464713a419092786bd
        {
            float deltaTime = Time.deltaTime;
            Debug.Log(deltaTime);


            rotateStrength = Input.GetAxis(input);
            if (rotateStrength != 0)
            {
                // Rotate the player
                rigid.AddTorque(transform.forward * torque * (rotateStrength * 0.4f));
            }

<<<<<<< HEAD
            // Movement keys, adds force in desired direction
            if (Input.GetKey(forward))
=======
            //Debug.Log(timeAccelerating);

            if (!accelerating)
            {
                idleToFullSound.time = timeAccelerating;
                fullToIdleSound.Stop();
                idleToFullSound.Play();
            }
            else
>>>>>>> 94c81290a65f955cb83b4a464713a419092786bd
            {
                rigid.AddForce(transform.right * move);


                timeAccelerating += deltaTime;
                if (timeAccelerating > 1)
                {
                    timeAccelerating = 1.0f;
                }

                Debug.Log(timeAccelerating);

                if (!accelerating)
                {
                    idleToFullSound.time = timeAccelerating;
                    fullToIdleSound.Stop();
                    idleToFullSound.Play();
                }
                else
                {
                    if (timeAccelerating < 1)
                    {
                        if (idleToFullSound.volume >= 1)
                        {
                            if (idleToFullSound.time > 0.8)
                            {
                                idleToFullSound.volume += AudioFadeFactor;
                                if (fullSound.isPlaying)
                                {
                                    if (fullSound.volume < 1)
                                    {
                                        fullSound.volume += AudioFadeFactor;
                                    }

                                }
                                /*
                                else
                                {
                                    fullSound.volume = 0;
                                    fullSound.Play();
                                }
                                */
                            }
                            else if (idleToFullSound.time < 0.2)
                            {
                                idleToFullSound.volume += AudioFadeFactor;
                                idleSound.volume -= AudioFadeFactor;
                            }
                        }
                    }
<<<<<<< HEAD
                    else
                    {
                        fullSound.volume = 1;
                    }
=======
                }
                else
                {
                    fullSound.volume = 1;
                }

            }

            accelerating = true;
        }
        else
        {
            timeAccelerating -= deltaTime;
            //Debug.Log("Else Deltatime: " + timeAccelerating);
>>>>>>> 94c81290a65f955cb83b4a464713a419092786bd

                }

                accelerating = true;
            }
            else
            {
                timeAccelerating -= deltaTime;
                Debug.Log("Else Deltatime: " + timeAccelerating);

                if (timeAccelerating < 0)
                {
                    timeAccelerating = 0;
                }

                if (accelerating)
                {
                    fullToIdleSound.time = timeAccelerating;
                    idleToFullSound.Stop();
                    fullToIdleSound.Play();
                }
                else
                {
                    if (timeAccelerating > 0)
                    {
                        if (fullToIdleSound.volume >= 1)
                        {
                            if (fullToIdleSound.time < 0.2)
                            {
                                fullToIdleSound.volume += AudioFadeFactor;
                                if (idleSound.isPlaying)
                                {
                                    if (idleSound.volume < 1)
                                    {
                                        idleSound.volume += AudioFadeFactor;
                                    }

                                }
                                /*
                                else
                                {
                                    idleSound.volume = 0;
                                    idleSound.Play();
                                }
                                */
                            }
                            else if (fullToIdleSound.time > 0.8)
                            {
                                fullToIdleSound.volume += AudioFadeFactor;
                                fullSound.volume -= AudioFadeFactor;
                            }
                        }
                    }
                    else
                    {
                        idleSound.volume = 1;
                    }

                }
                accelerating = false;
            }

<<<<<<< HEAD
            idleSound.volume = 1 - timeAccelerating * AudioFadeFactor * 2 - 0.1f;
            fullSound.volume = timeAccelerating * AudioFadeFactor * 2;

            if (Input.GetKey(reverse))
            {
                rigid.AddForce(-transform.right * move);
            }
            if (Input.GetKeyDown(boost))
            {
                move += 100;
                // Use rocket boost
            }
            else
            {
                // If not rocket boosted, old move speed
                move = OriginalMove;
            }
        }
        
=======
        idleSound.volume = 1 - timeAccelerating * AudioFadeFactor * 2 - 0.1f;
        fullSound.volume = timeAccelerating * AudioFadeFactor * 2;

        if (Input.GetKey(reverse))
        {
            rigid.AddForce(-transform.right * move);
        }

        if (Input.GetKeyDown(boost))
        {
            bec.Active = true;
            move = boostPower;
            // Use rocket boost

        }
        else if (Input.GetKeyUp(boost))
        {
            // If not rocket boosted, old move speed
            move = OriginalMove;
            bec.Active = false;
        }
    }

    public void Death()
    {
        RunawayEngine[] remainingEngines = gameObject.GetComponentsInChildren<RunawayEngine>();
        foreach (RunawayEngine re in remainingEngines)
        {
            re.Detach();
        }

        DetachedCockpit cockpit = GetComponentInChildren<DetachedCockpit>();
        if (cockpit != null)
        {
            cockpit.Detach();
        }

        Respawn();
        
        Destroy(gameObject);
    }

    void Respawn()
    {
        //Tell spawnPoint to spawn
        spawner.RespawnAfterDuration(respawnTime);
>>>>>>> 94c81290a65f955cb83b4a464713a419092786bd
    }
}