using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

//  use these to calibrate joystick input
    public float xMin, xMax, yMin, yMax;
//  in the inspector window

    void Start ()
    {

	}

	// Update
	void FixedUpdate ()
    {
        float hor = Input.GetAxis("Horizontal");
        if(hor <= xMax && hor >= xMin)
            hor = 0;

        float ver = Input.GetAxis("Vertical");
        if (ver <= yMax && ver >= yMin)
            ver = 0;

    //  un-comment this if you want to mess with the axis and need a
    //  visual value in the console window
        //Debug.Log("left/right: " + hor + "\nforward/back: " + ver);

        Vector3 move = new Vector3(-hor, 0.0f, ver);
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(-hor, ver) * 180 / Mathf.PI, 0);
        transform.position += move * speed * Time.deltaTime;
	}
}
