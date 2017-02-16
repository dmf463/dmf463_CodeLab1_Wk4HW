using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIOScript : MonoBehaviour {

    public List<string> linesOfFlight;

    public int listLine;

    public bool increasedCount;

    private const string FILE_NUMBER = "fileNum";
    private int fileNumber;
    public int FileNumber
    {
        get
        {
            fileNumber = PlayerPrefs.GetInt(FILE_NUMBER);
            return fileNumber;
        }
        set
        {
            Debug.Log("Application Turned Off");
            fileNumber = value;
            PlayerPrefs.SetInt(FILE_NUMBER, fileNumber);
            Debug.Log("FileNumber = " + fileNumber);
        }
    }

	// Use this for initialization
	void Start () {

        Debug.Log("Path: " + Application.dataPath);
        listLine = -1;
        increasedCount = false;


	}
	
	// Update is called once per frame
	void Update () {

        string fileName = "fracture" + FileNumber + ".txt";

        Debug.Log("increasedCount is " + increasedCount);

        string finalFilePath = Application.dataPath + "/TextFiles/" + fileName; //write a different file each time it starts up
        Debug.Log(finalFilePath);

        StreamWriter sw = new StreamWriter(finalFilePath, true); //write to this file, and add onto it each time

        if (increasedCount == true)
        {
            sw.WriteLine(linesOfFlight[listLine] + "                          ");
            increasedCount = false;
        }

        sw.Close();

    }

    void OnApplicationQuit()
    {
        FileNumber += 1;
        Debug.Log("FileNumber = " + fileNumber);
        
    }

    public void GetText(Transform currentBlock)
    {
        //So I want to write the string from whatever I'm looking at into the list, so that I can then write it to the file.
        //1. get the child from whatever I'm looking at
        //2. add the text from the child to the string list
        currentBlock = currentBlock.gameObject.transform.GetChild(0);
        linesOfFlight.Add(currentBlock.GetComponent<TextMesh>().text);
        increasedCount = true;
        listLine += 1;
        
    }
}