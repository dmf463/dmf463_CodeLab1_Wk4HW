using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RaycastTrigger : MonoBehaviour {

    [SerializeField] float timeLookedAt = 0f; //this is the time in seconds we've spent  looking at this thing
    public Image progressImage; //don't forget to assign this in the inspector

    public UnityEvent OnGazeComplete = new UnityEvent();
    public UnityEvent NotGazing = new UnityEvent();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //1. declare your raycast (origin of the array, and then which direction it shoots)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //2. setup our raycastHit info variable too
        RaycastHit rayHit = new RaycastHit();

        //3. we're ready to shoot our raycast....
        if (Physics.Raycast(ray, out rayHit, 10f))
        {
            if (rayHit.transform == this.transform) //are we actually looking at this thing
            {
                Debug.Log("Hitting Sphere");
                //transform.localScale *= 1.01f; //grow 1% if we're looking at this
                timeLookedAt = Mathf.Clamp01(timeLookedAt + Time.deltaTime); //after 1 second, this variable will be 1f;
                if (timeLookedAt == 1f)
                {
                    timeLookedAt = 0f;
                    OnGazeComplete.Invoke();
                }

            }
            else if(rayHit.transform != this.transform)
            {
                Debug.Log("Not Hitting Sphere");
                NotGazing.Invoke();
                timeLookedAt = 0;
            }
        }
        else
        {
            NotGazing.Invoke();
        }
       
        //update our UI image
        progressImage.fillAmount = timeLookedAt; //fillAmount is a float from 0-1;

    }
}
