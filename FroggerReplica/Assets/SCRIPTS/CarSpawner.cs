using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public float spawnDelay = .3f;

	public GameObject[] car;

	public Transform[] spawnPoints;

	float nextTimeToSpawn = 0f;

	void Update ()
	{
		if (nextTimeToSpawn <= Time.time)
		{
			SpawnCar();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

	void SpawnCar ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomCar = Random.Range(0, 4);
		Transform spawnPoint = spawnPoints[randomIndex];

		Instantiate(car[randomCar], spawnPoint.position, spawnPoint.rotation);
	}

}
