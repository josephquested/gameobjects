using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	public void RecieveActionInput (Cube cube)
	{
		React(cube);
	}

	void React (Cube cube)
	{
		if (cube.name == "Brown Cube")
		{
			Replace(cube);
		}

		if (cube.name == "Blue Cube")
		{
			Replace(cube);
		}
	}

	void Replace (Cube cube)
	{
		Instantiate(cube.gameObject, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
