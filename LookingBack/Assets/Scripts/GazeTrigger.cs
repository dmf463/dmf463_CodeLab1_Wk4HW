using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //1. is the camera looking or pointing at something?

        //get direction user is looking
        Vector3 camLookDirection = Camera.main.transform.forward;

        //direction from player to the target object( A to B = B-A)
        Vector3 vectorFromCamToTarget = transform.position - Camera.main.transform.position;

        //get the angle between our lookDir vs the objDir
        float angle = Vector3.Angle(camLookDirection, vectorFromCamToTarget);

        //do stuff based on that angle
        if (angle < 15f)
        {
            transform.localScale *= 1.01f; //if we are looking within 15 degrees FoV, grow object
        }

	}
}
