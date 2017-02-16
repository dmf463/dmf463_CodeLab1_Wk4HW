using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //rotate camera based on mouse
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
        Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0f);

		
	}
}
