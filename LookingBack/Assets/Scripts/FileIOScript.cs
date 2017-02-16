using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIOScript : MonoBehaviour {

	public string fileName = "temp.txt";

	public List<string> gazedText;

	// Use this for initialization
	void Start () {
		Debug.Log("Path: " + Application.dataPath);

		string finalFilePath = Application.dataPath + "/" + fileName;

        StreamWriter sw = new StreamWriter(finalFilePath, false);

        for (int i = 0; i < gazedText.Length; i++)
        {
            sw.WriteLine(gazedText[i] + " " + highScoreValues[i]);
        }

        sw.Close();


        StreamReader sr = new StreamReader(finalFilePath);

		int i = 0;

		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			string[] splitLine = line.Split(' ');

			string name = splitLine[0];
			string value = splitLine[1];

			Debug.Log("name: " + name);
			Debug.Log("value: " + value);

			gazedText.Add(name);
			highScoreValues.Add(value);

			i++;
		}

		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
