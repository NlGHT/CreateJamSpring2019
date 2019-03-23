using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
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
    float OriginalMove = 10;

    Rigidbody rigid; // rigid body for character

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rotateStrength = Input.GetAxis(input);
        if (rotateStrength != 0)
        {
            // Rotate the player
            rigid.AddTorque(transform.forward * torque * (rotateStrength*0.4f));
        }

        // Movement keys, adds force in desired direction
        if (Input.GetKey(forward))
        {
            rigid.AddForce(transform.right * move);
        }
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
}