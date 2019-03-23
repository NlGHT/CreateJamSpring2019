using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunawayEngine : MonoBehaviour
{
    //This is just to have a toggle in the editor for testing purposes
    public bool toggleState;

    [SerializeField]
    private bool detached = false;
    private Rigidbody rigid;
    public float thrustForce;
    public Vector3 spatialNoiseFactor = new Vector3(0.1f, 0.1f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleState)
        {
            toggleState = false;
            Detach();
        }

        if (detached)
        {
            ThrustForward();
        }
    }

    public void Detach()
    {
        detached = true;
        transform.SetParent(null);
        Destroy(GetComponent<ConfigurableJoint>());
    }

    private void ThrustForward()
    {
        Vector3 direction = transform.right + spatialNoise();
        direction.Normalize();
        rigid.AddForce(direction * thrustForce);
    }

    private Vector3 spatialNoise()
    {
        Vector3 noise = new Vector3(
            Random.Range(-spatialNoiseFactor.x, spatialNoiseFactor.x),
            Random.Range(-spatialNoiseFactor.y, spatialNoiseFactor.y),
            Random.Range(-spatialNoiseFactor.z, spatialNoiseFactor.z));

            return noise;
    }
}
