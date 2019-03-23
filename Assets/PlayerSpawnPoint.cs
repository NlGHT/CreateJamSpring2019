using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject spawnableObject;
    public Controller existingController;
    private bool respawning;

    // Start is called before the first frame update
    void Start()
    {
        if (existingController == null)
        {
            Respawn();
        }
        else
        {
            existingController.spawner = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnAfterDuration(float time)
    {
        if (!respawning)
        {
            Invoke("Respawn", time);
            respawning = true;
        }
    }

    void Respawn()
    {
        GameObject temp = Instantiate(spawnableObject, transform.position, transform.rotation);
        existingController = temp.GetComponent<Controller>();
        existingController.spawner = this;
        existingController.isActive = true;
        respawning = false;
    }
}
