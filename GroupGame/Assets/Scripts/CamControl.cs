using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    private Transform target;
    private int plyrNum;
    private string joy;
	// Use this for initialization
	void Start () {
        GetPlayerNumber();
        joy = "Player" + plyrNum + " Rightx";
        target = gameObject.transform.parent.GetComponentInParent<Transform>();
        Debug.Log(target.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis(joy)!=0)
        {
            float movement = Input.GetAxis(joy);
            transform.Translate(Vector3.right * movement * Time.deltaTime * 3.0f);
        }
        transform.LookAt(target);
	}

    void GetPlayerNumber()
    {
        PlayerControl pc = gameObject.transform.parent.GetComponentInParent<PlayerControl>();
        plyrNum = pc.GetPlayerNumber();
    }
}
