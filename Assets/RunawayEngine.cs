using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunawayEngine : MonoBehaviour
{
    [SerializeField]
    private bool detached;
    private Rigidbody rigid;
    public float thrustForce;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detached)
        {
            ThrustForward();
        }
    }

    public void Detach()
    {

    }

    private void ThrustForward()
    {
        rigid.AddForce(transform.right * thrustForce);
    }
}
