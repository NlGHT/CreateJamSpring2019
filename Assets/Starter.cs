using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public List<GameObject> players = new List<GameObject>();

    public GameObject r1pos;
    public GameObject r2pos;
    public GameObject r3pos;
    public GameObject g1pos;

    bool r1Spawned = false;
    bool r2Spawned = false;
    bool r3Spawned = false;
    bool g1Spawned = false;

    public GameObject redLightPrefab;
    public GameObject greenLightPrefab;

    public GameObject wayPoint;

    Vector3 startPos;

    float startTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;

        if (startTime <= 3.0 && startTime > 2.9)
        {
            if (!r1Spawned)
            {
                GameObject r1Temp = Instantiate(redLightPrefab, r1pos.transform);
                Destroy(r1Temp, 5);
                r1Spawned = true;
            }

        }

        if (startTime <= 2.0 && startTime > 1.9)
        {
            if (!r2Spawned)
            {
                GameObject r2Temp = Instantiate(redLightPrefab, r2pos.transform);
                Destroy(r2Temp, 4);
                r2Spawned = true;
            }

        }

        if (startTime <= 1.0 && startTime > 0.9)
        {
            if (!r3Spawned)
            {
                GameObject r3Temp = Instantiate(redLightPrefab, r3pos.transform);
                Destroy(r3Temp, 3);
                r3Spawned = true;
            }

        }

        if (startTime < 0)
        {
            if (!g1Spawned)
            {
                GameObject g1Temp = Instantiate(greenLightPrefab, g1pos.transform);
                Destroy(g1Temp, 2);
                g1Spawned = true;



                for (int i = 0; i < players.Count; i++)
                {
                    Controller tempController = players[i].GetComponent<Controller>();
                    tempController.isActive = true;
                }

            }

            transform.position = Vector3.Lerp(startPos, wayPoint.transform.position, -startTime);

            if (-startTime > 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
