using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{	
	Cube[] surroundingCubes;
	public int rowIndex;
	public int cellIndex;

	void Update ()
	{
		GetSurroundingCubes();
	}

	void GetSurroundingCubes ()
	{

	}

	public void RecieveActionInput (Cube cube)
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

		TransferData(newCube.GetComponent<Cube>());
		Destroy(gameObject);
	}

	void TransferData (Cube cube)
	{
		cube.rowIndex = rowIndex;
		cube.cellIndex = cellIndex;
	}
}
