using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour
{
	public Cube[] cubes;
	public Cube activeCube;

	public void RecieveActionInput ()
	{
		RaycastHit hitInfo = new RaycastHit();
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
		if (!hit) return;
		if (hitInfo.transform.gameObject.tag == "Cube")
		{
			Action(hitInfo.transform.gameObject);
		}
	}

	public void RecieveCubeInput (int cubeIndex)
	{
		activeCube = cubes[cubeIndex];
	}

	void Action (GameObject cube)
	{
		if (activeCube != null)
		{
			cube.GetComponent<Cube>().RecieveActionInput(activeCube);
		}
	}
}
