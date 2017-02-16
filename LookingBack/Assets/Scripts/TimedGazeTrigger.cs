using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //you need this to talk to UI elements, like images
using UnityEngine.Events;

public class TimedGazeTrigger : MonoBehaviour
{
    //serializing exposes private vars to the inspector
    [SerializeField] float timeLookedAt = 0f; //this is the time in seconds we've spent  looking at this thing
    public Image progressImage; //don't forget to assign this in the inspector

    public UnityEvent OnGazeComplete = new UnityEvent();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            timeLookedAt = Mathf.Clamp01(timeLookedAt + Time.deltaTime); //after 1 second, this variable will be 1f;
            if (timeLookedAt == 1f)
            {
                timeLookedAt = 0f;
                OnGazeComplete.Invoke();
            }
        }
        else
        {
            //decay progress if we're not looking at it
            timeLookedAt = Mathf.Clamp01(timeLookedAt - Time.deltaTime);

        }

        //update our UI image
        progressImage.fillAmount = timeLookedAt; //fillAmount is a float from 0-1;

    }
}