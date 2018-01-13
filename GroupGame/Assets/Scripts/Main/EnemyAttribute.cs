using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : Attribute {

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackRange_default;


    // Use this for initialization
    protected override void Start() {
    
    }

    // Update is called once per frame
    protected override void Update() {
      //  CamDelay();
    }
   
    public float GetAttackRange()
    {
        return attackRange;
    }

    public float GetDefaaultAttackRange()
    {
        return attackRange;
    }
    public int GetHp()
    {
        return (int)hp;
    }
    public void TakeDamage(int amount)
    {
        hp -= amount;
    }
}
