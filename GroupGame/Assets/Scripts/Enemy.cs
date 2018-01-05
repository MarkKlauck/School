using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    private int hp = 5;
    private NavMeshAgent agent;
    private Transform target;
    private Animator e_anim;
    private int attack = 0;
	// Use this for initialization
	void Start () {
        e_anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        FindTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(agent.remainingDistance > 10)
        {
            e_anim.SetBool("IsMoving", true);
            agent.isStopped = false;
        }
        else
        {
            e_anim.SetBool("IsMoving", false);
            agent.isStopped = true;
        }

        if(agent.isStopped == true)
        {
            StartCoroutine(AttackDelay(1));
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

    IEnumerator AttackDelay(float t)
    {
        yield return new WaitForSeconds(t);
        Attack();
    }

    private void Attack()
    {
        if(attack == 0)
        {
            e_anim.SetTrigger("IsAttack");
            attack = 1;
        }
        else if(attack == 1)
        {
            e_anim.SetTrigger("IsAttack2");
            attack = 0;
        }
    }
}
