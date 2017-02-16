using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewRayCastTrigger : MonoBehaviour {

    float timeLookedAt = 0f;
    public float rayDistance;
    public Image progressImage;
    public float moveSpeed;
    public GameObject placeToMove;
    public UnityEvent onGazeComplete;

    bool hasMoved = false;

    GameObject textSaver;
    FileIOScript fileScript;

	// Use this for initialization
	void Start () {

        textSaver = GameObject.Find("TextSaver");
        fileScript = textSaver.GetComponent<FileIOScript>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //1. declare your raycast (origin of the array, and then the direction it shoots)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //2. setup our raycastHit info variable
        RaycastHit rayHit = new RaycastHit();

        //3 we're ready to shoot the raycast
        if (Physics.Raycast(ray, out rayHit, rayDistance))
        {
            if (rayHit.transform == this.transform) //are we looking at this thing
            {
                Debug.Log("Hitting: " + this.gameObject.name);
                timeLookedAt = Mathf.Clamp01(timeLookedAt + Time.deltaTime); //after 1 second, this bariable will be 1f;
                if (timeLookedAt == 1f && hasMoved == false)
                {
                    timeLookedAt = 0f;
                    onGazeComplete.Invoke();
                    hasMoved = true;
                    fileScript.GetText(this.transform);
                }
            }
        }

        //update our UI image
        progressImage.fillAmount = timeLookedAt; //fillAmount is a float from 0-1;

    }

    public void moveTowardsObject()
    {
        //float step = moveSpeed * Time.deltaTime;
        //Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, this.transform.position, step);
        Camera.main.transform.parent.position = new Vector3((placeToMove.transform.position.x), (placeToMove.transform.position.y), (placeToMove.transform.position.z));
    }
}
