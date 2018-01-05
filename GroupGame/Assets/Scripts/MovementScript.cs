using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    private float forward, turn;
    private Animator anim;
    Rigidbody rody;
    bool m_IsGrounded;
    float m_OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float m_TurnAmount;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;
    float m_CapsuleHeight;
    Vector3 m_CapsuleCenter;
    CapsuleCollider m_Capsule;
    bool m_Crouching;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Move()
    {
        forward = Input.GetAxis(gameObject.GetComponent<PlayerControl>().GetControllerAxis('x'));
        turn = Input.GetAxis(gameObject.GetComponent<PlayerControl>().GetControllerAxis('y'));

    }
}
