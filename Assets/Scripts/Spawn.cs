using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	public GameObject player;
	public GameObject crate;
	public GameObject enemy1;
	public int numberOfCrates;
	public int numberOfEnemies;
	public int columns = 15;
	public int rows = 9;
	private List<Vector3> gridPositions = new List<Vector3>();

	void Awake()
	{
		InitialiseList();
		SpawnPlayer();
		SpawnCrates();
		SpawnEnemies();
	}

	void InitialiseList()
	{
		gridPositions.Clear();
		for (int x = -columns/2; x <= columns/2; x++)
		{
			for (int y = -rows/2; y <= rows/2; y++)
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

	private void SpawnEnemies()
	{
		for (int i = 0; i < numberOfEnemies; i++)
		{
			int randomLocation = Random.Range(0, gridPositions.Count);
			Vector3 location = gridPositions[randomLocation];
			gridPositions.RemoveAt(randomLocation);
			Instantiate(enemy1, location, Quaternion.identity);
		}
	}
}
