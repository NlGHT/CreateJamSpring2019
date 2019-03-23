using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour
{
    public KeyCode leftRotate = KeyCode.A;
    public KeyCode rightRotate = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode boost = KeyCode.Q;
    Rigidbody rigid;
    public float torque = 10;
    public float move = 10;
    float OriginalMove = 10;
    public float rotateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightRotate))
        {
            // Rotate right
            transform.Rotate(0, 0, rotateSpeed);
        }

        if (Input.GetKey(leftRotate))
        {
            // Rotate left
            rigid.AddTorque(transform.up * torque);
        }
        if (Input.GetKey(up))
        {
            rigid.AddForce(transform.right * move);
            // Add force on y-axis upwards - eg. move up
        }
        if (Input.GetKeyDown(boost))
        {
            move += 100;
            // Use rocket boost
        }
        else
        {
            move = OriginalMove;
        }
    }
}