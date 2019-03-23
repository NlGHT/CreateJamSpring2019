using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    public List<GameObject> PlayersFinished = new List<GameObject>();

    public GameObject nextMapTipPrefab;
    public GameObject tipSpawnPoint;

    int sceneToStart = 1;
    int numScenes = 1; // Scene 0 is Main menu

    bool isFinished = false;

    public List<GameObject> placeList = new List<GameObject>();


    private void Update()
    {
        if (isFinished)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sceneToStart = Random.Range(1, numScenes);

                SceneManager.LoadScene(sceneToStart);
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
    }

    // When a collider enters the collider of object, set them as done with level
    void OnTriggerEnter(Collider other)
    {

        if (!PlayersFinished.Contains(other.gameObject) && other.tag == "Player")
        {
            // If the player is not in the finished list, add them and destroy them
            PlayersFinished.Add(other.gameObject);
            Debug.Log("Player finished map");
            Destroy(other.gameObject);

            TextMesh tempText = placeList[PlayersFinished.Count - 1].GetComponent<TextMesh>();
            tempText.text = other.gameObject.name;

            if (PlayersFinished.Count >= 1)
            {
                // Everyone finished the map, go to next one (randomized)
                Debug.Log("All are done");

                GameObject tempTip = Instantiate(nextMapTipPrefab);

                isFinished = true;

                
            }
        }
    }
}
