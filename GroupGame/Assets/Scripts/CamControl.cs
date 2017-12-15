﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    private float yOffset;

    private Transform target;
    private int joyNum;
    private string joy;
	// Use this for initialization
	void Start () {
        target = gameObject.transform.parent.GetComponentInParent<Transform>();
        yOffset = 1.5f;
        joyNum = GetJoyNumber();
        joy = "Player" + joyNum + " Rightx"; //need to add input manager
	}
	
	// Update is called once per frame
	void Update () {
        
         if(Input.GetAxis(joy)!=0)
         {
             float movement = Input.GetAxis(joy);
             transform.Translate(Vector3.right * movement * Time.deltaTime * 3.0f);
         }
        transform.LookAt(target.position + new Vector3(0, yOffset, 0));
	}

    public int GetJoyNumber()
    {
        PlayerControl pc = gameObject.transform.parent.GetComponentInParent<PlayerControl>();
        return pc.GetJoystickNumber();
    }
}
