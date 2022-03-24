using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public int currentPoint;
    public int varX;
    public int varY;
    public float platformSpeed;
    public Transform platform;
    void Start()
    {
        platformSpeed = Random.Range(1, 5);
        if (varY == 0)
        {
            points[0].position = new Vector3(Mathf.Clamp(platform.position.x - varX, -2.2f, -1), platform.position.y - varY, platform.position.z);
            points[1].position = new Vector3(Mathf.Clamp(platform.position.x + varX, 1, 2.2f), platform.position.y + varY, platform.position.z);
        }
        else if (varX == 0)
        {
            points[0].position = new Vector3(platform.position.x, platform.position.y + varY, platform.position.z);
            points[1].position = new Vector3(platform.position.x, platform.position.y - varY, platform.position.z);
        }

        points[0].parent = null;
        points[1].parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, Time.deltaTime * platformSpeed);
        if (Vector3.Distance(platform.position, points[currentPoint].position) <= .5f)
        {
            currentPoint++;
            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }

        }
    }
}
