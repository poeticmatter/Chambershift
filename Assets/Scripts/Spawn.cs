using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	public GameObject player;
	public GameObject crate;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject spawnPoint;

	public int numberOfCrates;
	public int columns = 16;
	public int rows = 10;
	public int portals = 3;
	private List<Vector3> gridPositions = new List<Vector3>();
	public List<Transform> spawnPoints = new List<Transform>();

	public float minSpawnDelay;
	public float maxSpawnDelay;
	public float enemy1Chance;
	public float enemy2Chance;

	public GameObject spawnAnimation;

	private float spawnTimer = 0;

	public static Spawn inst;

	void Awake()
	{
		inst = this;
		InitialiseList();
	}

	void Start()
	{
		SpawnPlayer();
		SpawnCrates();
		SpawnSpawnPoints();
		GameManager.inst.SetupComplete();
	}

	void Update()
	{
		if (!GameManager.inst.IsGameRunning())
		{
			return;
		}
		if (spawnTimer > 0)
		{
			spawnTimer -= Time.deltaTime;
		} else
		{
			spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
			SpawnEnemies();
		}
	}

	void InitialiseList()
	{
		gridPositions.Clear();
		for (int x = 0; x <= columns; x++)
		{
			for (int y = 0; y <= rows; y++)
			{
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

	private void SpawnPlayer()
	{
		int min = Mathf.RoundToInt(gridPositions.Count * 0.25f);
		int max = Mathf.RoundToInt(gridPositions.Count * 0.75f);
        int randomLocation = Random.Range(min, max);
		Vector3 location = gridPositions[randomLocation];
		gridPositions.RemoveAt(randomLocation);
		Instantiate(player, location, Quaternion.identity);
	}

	private void SpawnCrates()
	{
		for (int i = 0; i < numberOfCrates; i++)
		{
			int randomLocation = Random.Range(0, gridPositions.Count);
			Vector3 location = gridPositions[randomLocation];
			gridPositions.RemoveAt(randomLocation);
			Instantiate(crate, location, Quaternion.identity);
		}
	}

	private void SpawnSpawnPoints()
	{
		for (int i = 0; i < portals; i++)
		{
			int randomLocation = Random.Range(0, gridPositions.Count);
			Vector3 location = gridPositions[randomLocation];
			gridPositions.RemoveAt(randomLocation);
			Transform newSpawnPoint = ((GameObject)Instantiate(spawnPoint, location, Quaternion.identity)).transform;
			spawnPoints.Add(newSpawnPoint);
		}
	}

		
	private void SpawnEnemies()
	{
		if (spawnPoints.Count <= 0)
		{
			return;
		}
		int randomLocation = Random.Range(0, spawnPoints.Count);
		Transform spawnPoint = spawnPoints[randomLocation];
		GameObject animation = (GameObject) Instantiate(spawnAnimation, spawnPoint.position, Quaternion.identity);
		animation.transform.parent = spawnPoint;
		StartCoroutine(SpawnEnemy(spawnPoint, randomLocation, 0.7f,animation));
		
	}

	protected IEnumerator SpawnEnemy(Transform location, int index, float delay, GameObject animation)
	{
		float timeCouner = 0;
		while (timeCouner < delay)
		{
			timeCouner += Time.deltaTime;
			yield return null;
		}
		if (index < spawnPoints.Count && spawnPoints[index].transform == location)
		{
			float randomEnemy = Random.Range(0, enemy1Chance + enemy2Chance);
			GameObject enemy = randomEnemy < enemy1Chance ? enemy1 : enemy2;
			Instantiate(enemy, location.position, Quaternion.identity);
			Destroy(animation.gameObject);
		}

	}
}

