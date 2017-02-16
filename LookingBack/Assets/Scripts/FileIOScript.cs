using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIOScript : MonoBehaviour {

    public string fileName = "temp.text";

    public List<string> linesOfFlight;

	// Use this for initialization
	void Start () {

        Debug.Log("Path: " + Application.dataPath);

        string finalFilePath = Application.dataPath + "/TextFiles/" + fileName;

        //So I want to write the string from whatever I'm looking at into the list, so that I can then write it to the file. 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetText(Transform currentBlock)
    {
        currentBlock = currentBlock.gameObject.transform.GetChild(0);
        linesOfFlight.Add(currentBlock.GetComponent<TextMesh>().text);
    }
}