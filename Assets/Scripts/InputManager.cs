using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	ActionManager actionManager;

	void Awake ()
	{
		actionManager = GetComponent<ActionManager>();
	}

	void Update ()
	{
		UpdateActionInput();
		UpdateCubeInput();
	}

	void UpdateActionInput ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			actionManager.RecieveActionInput();
		}
	}

	void UpdateCubeInput ()
	{
		int keyCode = 666;
	 	if (Input.GetKeyDown(KeyCode.Alpha0)) keyCode = 0;
	 	if (Input.GetKeyDown(KeyCode.Alpha1)) {
			keyCode = 1;
			print("clicked 1!");
		}
	 	if (Input.GetKeyDown(KeyCode.Alpha2)) keyCode = 2;
		if (keyCode != 666) actionManager.RecieveCubeInput(keyCode);
	}
}
