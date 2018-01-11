using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCamera : MonoBehaviour {
    private Canvas canvas;

    public string pName;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        GameObject targetCam = GameObject.Find(pName);
        canvas.worldCamera = targetCam.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(canvas.worldCamera == null)
        {
            GameObject targetCam = GameObject.Find(pName);
            canvas.worldCamera = targetCam.GetComponent<Camera>();
        }
	}
}
