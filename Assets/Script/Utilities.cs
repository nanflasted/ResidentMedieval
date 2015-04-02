using UnityEngine;
using System.Collections;

public static class Utilities {

	public static Vector3 parseV3(string input)//parse a vecter3d from string in order to load stuff
	{
		Vector3 output = new Vector3(0f,0f,0f);
		string[] split = new string[3];
		split = input.Substring(1,input.Length-2).Split(',');
		output.x = float.Parse(split[0]);
		output.y = float.Parse(split[1]);
		output.z = float.Parse(split[2]);

		return output;
	}
}
