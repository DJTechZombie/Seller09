using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject[] fruitPrefab;
	public Transform[] spawnPoints;

	public float minDelay = .1f;
	public float maxDelay = 1f;
    int fruitIndex = 0;

    // Use this for initialization
    void Start () {
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
		while (GameManager.instance.canSpawn)
		{
            GameManager.instance.totalFruit++;
			float delay = Random.Range(minDelay, maxDelay)*GameManager.instance.SpawnSpeedMult;
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

            if(GameManager.instance.fruitSelection == 0)
            { 
            fruitIndex = Random.Range(0, fruitPrefab.Length);
            }
            else
            {
            fruitIndex = GameManager.instance.fruitSelection-1;
            }
            GameObject spawnedFruit = Instantiate(fruitPrefab[fruitIndex], spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
		}
	}
	
}
