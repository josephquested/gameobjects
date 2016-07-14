using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	CubeManager cubeManager;
	public GameObject[] surroundingCubes;
	public int rowIndex;
	public int cellIndex;

	void Awake ()
	{
		cubeManager = GameObject.FindWithTag("GameManager").GetComponent<CubeManager>();
	}

	void Update ()
	{
		GetSurroundingCubes();
	}

	void GetSurroundingCubes ()
	{
		if (rowIndex != 0)
		{
			surroundingCubes[0] = cubeManager.cubeArray[rowIndex - 1, cellIndex];
		}
		if (cellIndex != cubeManager.cubeArray.GetLength(0) - 1)
		{
			surroundingCubes[1] = cubeManager.cubeArray[rowIndex, cellIndex + 1];
		}
		if (rowIndex != cubeManager.cubeArray.GetLength(0) - 1)
		{
			surroundingCubes[2] = cubeManager.cubeArray[rowIndex + 1, cellIndex];
		}
		if (cellIndex != 0)
		{
			surroundingCubes[3] = cubeManager.cubeArray[rowIndex, cellIndex - 1];
		}
	}

	public void ReceiveActionInput (Cube cube)
	{
		React(cube);
	}

	void React (Cube cube)
	{
		if (cube.name == "Brown Cube") Replace(cube);
		if (cube.name == "Blue Cube") Replace(cube);
	}

	void Replace (Cube cube)
	{
		GameObject newCube = (GameObject)Instantiate(
			cube.gameObject,
			transform.position,
			transform.rotation
		);
		cubeManager.cubeArray[rowIndex, cellIndex] = newCube;
		TransferData(newCube.GetComponent<Cube>());
		Destroy(gameObject);
	}

	void TransferData (Cube cube)
	{
		cube.rowIndex = rowIndex;
		cube.cellIndex = cellIndex;
	}
}
