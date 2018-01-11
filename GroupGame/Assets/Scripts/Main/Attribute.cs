﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float maxHP;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float damage_default;
    [SerializeField]
    protected bool isDying = false;
    [SerializeField]
    protected bool isAlive = true;

    protected virtual void Start()
    {
        SetMaxHP(100);
        AddHP(100);
        SetDamage(40);
    }

    protected virtual void Update()
    {
        
    }

    public void AddHP(int amnt)
    {
        hp += amnt;
        if (hp >= maxHP)
            hp = maxHP;
    }

    public void AddMaxHP(int amnt)
    {
        maxHP += amnt;
    }

    public void SetMaxHP(int amnt)
    {
        maxHP = amnt;
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }

    public float GetDamage()
    {
        return damage;
    }


    public void TakeDamage(int amnt)
    {
        hp -= amnt;
        if (hp <= 0.0f)
        {
            hp = 0.0f;
            isDying = false;
        }
    }

    public void SetDamage(int amnt)
    {
        damage = amnt;
    }

    public void AddDamage(int amnt)
    {
        damage += amnt;
    }

    public void ResetDamage()
    {
        damage = damage_default;
    }
    public bool IsDying()
    {
        return isDying;
    }

    public bool IsAlive()
    {
        return isAlive;
    }


}