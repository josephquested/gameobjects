using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	CubeManager cubeManager;
	public string type;
	public GameObject[] neighbours;
	public int rowIndex;
	public int cellIndex;

	void Awake ()
	{
		cubeManager = GameObject.FindWithTag("GameManager").GetComponent<CubeManager>();
	}

	void Update ()
	{
		GetNeighbours();
		ProcessNeighbours();
	}

	void GetNeighbours ()
	{
		if (rowIndex != 0)
		{
			neighbours[0] = cubeManager.cubeArray[rowIndex - 1, cellIndex];
		}
		if (cellIndex != cubeManager.cubeArray.GetLength(0) - 1)
		{
			neighbours[1] = cubeManager.cubeArray[rowIndex, cellIndex + 1];
		}
		if (rowIndex != cubeManager.cubeArray.GetLength(0) - 1)
		{
			neighbours[2] = cubeManager.cubeArray[rowIndex + 1, cellIndex];
		}
		if (cellIndex != 0)
		{
			neighbours[3] = cubeManager.cubeArray[rowIndex, cellIndex - 1];
		}
	}

	void ProcessNeighbours ()
	{
		for (int i = 0; i <= 3; i++)
		{
			if (neighbours[i] != null)
			{
				ReactToNeighbour(neighbours[i].GetComponent<Cube>());
			}
		}
	}

	public virtual void ReactToNeighbour (Cube cube)
	{

	}

	public void ReceiveActionInput (Cube cube)
	{
		React(cube);
	}

	public virtual void React (Cube cube)
	{
		if (cube.type == "Brown") Replace(cube);
		if (cube.type == "Blue") Replace(cube);
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
