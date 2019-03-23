using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public List<GameObject> PlayersFinished = new List<GameObject>();

    // When a collider enters the collider of object, set them as done with level
    void OnTriggerEnter(Collider other)
    {

        if (!PlayersFinished.Contains(other.gameObject) && other.tag == "Player")
        {
            // If the player is not in the finished list, add them and destroy them
            PlayersFinished.Add(other.gameObject);
            Debug.Log("Player finished map");
            Destroy(other.gameObject);

            if (PlayersFinished.Count >= 4)
            {
                // Everyone finished the map, go to next one (randomized)
                Debug.Log("All are done");
            }
        }
    }
}
