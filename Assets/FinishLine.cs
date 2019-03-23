using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // When a collider enters the collider
    void OnTriggerEnter(Collider other)
    {
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.green;
    }
}
