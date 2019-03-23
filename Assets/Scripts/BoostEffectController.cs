using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEffectController : MonoBehaviour
{
    public ParticleSystem[] boostParticleSystem;

    //This is just to have a toggle in the editor for testing purposes
    public bool toggleState;

    private bool active = false;

    /// <summary>
    ///Changing the bool Active will toggle the particle effect.
    /// </summary>
    public bool Active
    {
        get { return active; }
        set
        {
            if (value == active) return;

            
                active = value;

                ToggleParticleEffect();         
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ToggleParticleEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleState)
        {
            toggleState = false;
            Active = !Active;
        }
    }

    /// <summary>
    /// Toggles the boost particle effect based on the value of bool active.
    /// </summary>
    private void ToggleParticleEffect()
    {
        if (!active)
        {
            foreach (ParticleSystem ps in boostParticleSystem)
            {
                ps.Stop();
            }
        }
        else
        {
            foreach (ParticleSystem ps in boostParticleSystem)
            {
                ps.Play();
            }
        }
    }
}
