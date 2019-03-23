using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionWithParts : MonoBehaviour
{
    public GameObject[] objectsToIgnore;

    // Start is called before the first frame update
    void Start()
    {
        Collider myCol = gameObject.GetComponent<Collider>();
        foreach (GameObject go in objectsToIgnore)
        {
            Physics.IgnoreCollision(go.GetComponent<Collider>(), myCol, true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
