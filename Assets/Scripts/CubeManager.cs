using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeManager : MonoBehaviour
{
	public GameObject cubePrefab;
	public GameObject[,] cubeArray;
	public int boardSize;

	void Start ()
	{
		cubeArray = new GameObject[boardSize, boardSize];
		SpawnCubes();
	}

	void SpawnCubes ()
	{
		for (int i = 0; i < boardSize; i++)
		{
			for (int j = 0; j < boardSize; j++)
			{
				GameObject cube = (GameObject)Instantiate(
					cubePrefab,
					new Vector3(i, 0, j),
					transform.rotation
				);

				cubeArray[i,j] = cube;
				cube.GetComponent<Cube>().rowIndex = i;
				cube.GetComponent<Cube>().cellIndex = j;
			}
		}
	}
}
