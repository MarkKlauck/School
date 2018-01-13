using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour {

    private CharacterController cc;
    private string Xaxis = "";
    private string Zaxis = "";
    private float forwardMotion = 0f;
    private float sideMotion = 0f;
    private Vector3 movement = Vector3.zero;
    private Animator anim;

    public float moveSpeed;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        if(Xaxis == "" || Zaxis == "")
        {
            SetControllerInput();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    private void SetControllerInput()
    {
        Xaxis = GetComponent<PlayerControl>().GetControllerAxis('x');
        Zaxis = GetComponent<PlayerControl>().GetControllerAxis('y');
    }
    private void Move()
    {
        if (Xaxis == "" || Zaxis == "")
        {
            SetControllerInput();
        }
        forwardMotion = Input.GetAxis(Zaxis);
        sideMotion = Input.GetAxis(Xaxis);
        /*
        forwardMotion = Input.GetAxis("Joystick1 Lefty");
        sideMotion = Input.GetAxis("Joystick1 Leftx");*/
        if(forwardMotion < 0f)
        {
            forwardMotion = 0f;
        }

        if(cc.isGrounded)
        {
            movement = new Vector3(sideMotion, 0, forwardMotion);
            movement = transform.TransformDirection(movement);
            movement *= moveSpeed;
            
        }
        ApplyExtraTurnRotation(forwardMotion, sideMotion);
        anim.SetFloat("Forward", forwardMotion, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", sideMotion, 0.1f, Time.deltaTime);
        anim.SetBool("Crouch", false);
        anim.SetBool("OnGround", cc.isGrounded);
        movement.y -= 9f * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
    private void ApplyExtraTurnRotation(float forwardAmount, float turnAmount)
    {
        float turnSpeed = Mathf.Lerp(180, 360, forwardAmount);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }
}
