using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float defaultPosX;
    public float maxDistX = 11.2f;
    public float minDistX = 4.4f;
    public float moveSpeed = 20f;
    public float moveDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x <= minDistX)
        {
            moveDir = 1;
        }
        else if(pos.x >= maxDistX)
        {
            moveDir = -1;
        }
        pos.x += 1 * Time.deltaTime * moveDir;
        transform.position = pos;

    }
}
