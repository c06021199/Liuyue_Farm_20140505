using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;

public class SaveExample : MonoBehaviour {
	
	public JSONNode N;

	public void load_file(string filepath)
	{		
		FileInfo t = new FileInfo (filepath);	//These 5 lines are needed to read the save file, you can just copy it

		StreamReader sr = t.OpenText ();

		string load_string = sr.ReadToEnd ();

		sr.Close ();

		sr.Dispose ();

		N = JSON.Parse ( load_string );			//parse the string to be JSONNode
	}

	public void save_file(string filepath)
	{
		//string filepath = Application.dataPath  + @"/save.txt";		//set file path, the file path will be changed for iOS

		string save_string = N.ToString ();		//translate JSONNode -> string

		FileInfo t = new FileInfo (filepath);	//These 5 lines are needed to write the save file, you can just copy it

		StreamWriter sw = t.CreateText ();

		sw.WriteLine (save_string);

		sw.Close ();

		sw.Dispose ();
	}

}
