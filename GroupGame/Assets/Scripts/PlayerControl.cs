using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private float hor, ver;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(hor, 0.0f, ver);
        transform.Translate(move * Time.deltaTime * 10.0f);
       // rb.AddForce(move * Time.deltaTime * 10.0f);
	}
}
