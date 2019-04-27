using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform[] spawnPoints;

    public float minDelay = 10f;
    public float maxDelay = 30f;
    public float delayMult = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {

        switch(GameManager.instance.level)
        {
            case 1:
            case 2:
            case 3:
                delayMult = 1f;
                break;
            case 4:
            case 5:
                delayMult = .9f;
                break;
            case 6:
            case 7:
            case 8:
                delayMult = .8f;
                break;
            case 9:
            case 10:
                delayMult = .7f;
                break;
            case 11:
            case 12:
                delayMult = .6f;
                break;
            default:
                delayMult = .5f;
                break;
        }
        while (GameManager.instance.canSpawn)
        {
            float delay = Random.Range(minDelay, maxDelay)*delayMult;
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }

}
