using UnityEngine;
using System.Collections;

public class BrownCube : Cube
{
	public bool wet;

	public override void React (Cube cube)
	{

	}

	public override void ReactToNeighbour (Cube cube)
	{
		if (cube.type == "Blue") wet = true;
	}
}
