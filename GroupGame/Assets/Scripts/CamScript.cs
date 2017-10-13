using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;
    
	void Start () {
        offset = player.transform.position - transform.position;
        transform.LookAt(player.transform);
	}
	
	void LateUpdate () {
        transform.position = player.transform.position - offset;
        transform.LookAt(player.transform);
    }
}
