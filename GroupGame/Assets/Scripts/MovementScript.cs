using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    private float forward, turn;
    private Animator anim;
    private CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Move()
    {
        forward = Input.GetAxis(gameObject.GetComponent<PlayerControl>().axisx);
        turn = Input.GetAxis(gameObject.GetComponent<PlayerControl>().axis);

    }
}
