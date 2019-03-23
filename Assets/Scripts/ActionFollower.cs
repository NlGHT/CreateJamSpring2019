using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFollower : MonoBehaviour
{

    public GameObject[] players;
    public Camera camera;
    public float maxZDistance;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float topY = 0;
        float bottomY = 0;
        float rightX = 0;
        float leftX = 0;
        for (int i = 0; i < players.Length; i++)
        {
            GameObject loopPlayer = players[i];
            Vector3 loopPos = loopPlayer.transform.position;
            topY = Mathf.Max(topY, loopPos.y);
            rightX = Mathf.Max(rightX, loopPos.x);
            bottomY = Mathf.Min(bottomY, loopPos.y);
            leftX = Mathf.Min(leftX, loopPos.x);
        }

        Vector2 centerXY = new Vector2((rightX + leftX) / 2, (topY + bottomY) / 2);

        float distanceX = rightX - leftX;
        float distanceY = topY - bottomY;
        Debug.Log("distanceY: " + distanceY);
        Debug.Log("distanceX: " + distanceX);

        float verticalFOV = camera.fieldOfView;
        Debug.Log("Vertical FOV" + verticalFOV);
        float horizontalFOV = verticalFOV / 9 * 16;
        Debug.Log("Horizontal FOV" + horizontalFOV);

        float zDistance = -10.0f;
        if (distanceX/16 > distanceY/9)
        {
            zDistance = getZDistance(horizontalFOV, distanceX);
        }
        else
        {
            zDistance = getZDistance(verticalFOV, distanceY);
        }

        Debug.Log("zDistance = " + zDistance);

        zDistance = -Mathf.Clamp(zDistance, 0, 12);

        Vector3 target = new Vector3(centerXY.x, centerXY.y, zDistance);
        //Vector3 targetMapped = map()
        Vector3 lerpPos = Vector3.Lerp(camera.transform.position, target, 0.05f);

        camera.transform.position = lerpPos;
    }

    float getZDistance(float FOV, float distance)
    {
        return distance / Mathf.Tan(Mathf.Deg2Rad * (FOV / 2));
    }
}
