using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int hp, damage;

    //collision stuff here?

	// Use this for initialization
	void Start () {
        SetHp(100);
        SetDamage(40);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //use to set hp to a specified amount
    public void SetHp(int amnt)
    {
        hp = amnt;
    }
    //use to increase/decrease hp
    public void TakeDamage(int n)
    {
        hp -= n;
    }
    //use to set damage to a specified amount
    public void SetDamage(int amnt)
    {
        damage = amnt;
    }
}
