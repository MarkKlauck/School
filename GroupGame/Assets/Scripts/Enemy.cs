using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    private int hp = 5;
    private NavMeshAgent agent;
    private Transform target;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        FindTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!agent)
        {
            agent = GetComponent<NavMeshAgent>();
            FindTarget();
        }
        else
        {
            FindTarget();
        }
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void TakeDamage(int amount)
    {
        hp -= amount;
    }
    void FindTarget()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        int n = allPlayers.Length;
        target = allPlayers[0].transform;
        float d1 = Vector3.Distance(transform.position, target.transform.position);
        for(int i = 0;i < n;i++)
        {
            float d2 = Vector3.Distance(transform.position, allPlayers[i].transform.position);
            if(d2 < d1)
            {
                target = allPlayers[i].transform;
            }
        }
        agent.SetDestination(target.position);
    }
}
