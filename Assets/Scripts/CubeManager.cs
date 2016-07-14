using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour
{
	public GameObject cubePrefab;
	public int boardSize;

	void Start ()
	{
		SpawnCubes();
	}

	void SpawnCubes ()
	{
		for (int i = 0; i <= boardSize; i++)
		{
			for (int j = 0; j <= boardSize; j++)
			{
				Instantiate(cubePrefab, new Vector3(i, 0, j), transform.rotation);
			}
		}
	}
}
