using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedCockpit : MonoBehaviour
{
    //This is just to have a toggle in the editor for testing purposes
    public bool toggleState;

    [SerializeField]
    private bool detached = false;
    private Rigidbody rigid;
    public uint selfDestructTime = 10;

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
    }

    public void Detach()
    {
        detached = true;
        transform.SetParent(null);
        Destroy(GetComponent<ConfigurableJoint>());
        Destroy(gameObject, selfDestructTime);
    }
}