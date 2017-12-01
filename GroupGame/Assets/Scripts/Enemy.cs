using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindTarget()
    {
        float d;
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject g in allPlayers)
        {
            
        }
    }
}
