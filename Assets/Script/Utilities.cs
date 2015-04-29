using UnityEngine;
using System.Collections;
using System.IO;
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
	public static void Save()
	{
		StreamWriter saver;

		saver = new StreamWriter("save.dat");
		saver.WriteLine(Application.loadedLevel);
		saver.Close();
	}
	
	public static void Load(){
		StreamReader loader;
		if (File.Exists("save.dat"))
		{
			loader = new StreamReader("save.dat");
			int level = int.Parse(loader.ReadLine());
			loader.Close();
			Application.LoadLevel(level);
		}
	}
}
