using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupController : MonoBehaviour
{
    public GameObject pickup;

    private bool hasSpawned = false;

    private float spawnTime;

    private float _minX = -6f, maxX = 6f, minY = -3.1f, maxY = 3.7f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasSpawned && Time.timeSinceLevelLoad >= spawnTime)
        {
            float spawnX = Random.Range(_minX, maxX);
            float spawnY = Random.Range(minY, maxY);
            Instantiate(pickup, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            hasSpawned = true;
        }
    }
}
