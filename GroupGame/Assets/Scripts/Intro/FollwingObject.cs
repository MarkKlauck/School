using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwingObject : MonoBehaviour {

    // Use this for initialization
    public Vector3 offset;
    public GameObject obj;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vPos = obj.transform.position;
        transform.position = vPos + offset;
		
	}
}
