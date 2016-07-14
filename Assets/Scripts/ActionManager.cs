using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour
{
	public Cube[] cubes;
	public Cube activeCube;

	public void ReceiveActionInput ()
	{
		RaycastHit hitInfo = new RaycastHit();
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
		if (!hit) return;
		if (hitInfo.transform.gameObject.tag == "Cube")
		{
			Action(hitInfo.transform.gameObject);
		}
	}

	public void ReceiveCubeInput (int cubeIndex)
	{
		activeCube = cubes[cubeIndex];
	}

	void Action (GameObject cube)
	{
		if (activeCube != null)
		{
			cube.GetComponent<Cube>().ReceiveActionInput(activeCube);
		}
	}
}
