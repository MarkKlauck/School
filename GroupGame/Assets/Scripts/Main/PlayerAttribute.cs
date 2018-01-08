using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : Attribute {

    [SerializeField]
    private float mp;
    [SerializeField]
    private float maxMP;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speed_default;

    // Use this for initialization
    protected override void Start() {

    }

    // Update is called once per frame
    protected override void Update() {
        //  CamDelay();
    }

    public void AddMP(int amnt)
    {
        mp += amnt;
        if (mp >= maxMP)
            mp = maxMP;
    }

    public void ConsumeMP(int amnt)
    {
        mp -= amnt;
        if (mp <= 0.0f)
        {
            mp = 0.0f;
        }
    }

    public void AddMaxMP(int amnt)
    {
        maxMP += amnt;
    }

    public void SetMaxMP(int amnt)
    {
        maxMP = amnt;
    }

    public float GetMaxMP()
    {
        return maxMP;
    }

    public float GetMP()
    {
        return mp;
    }


    public void SetSpeed(float amnt)
    {
        speed = amnt;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetDefaultSpeed(float amnt)
    {
        speed_default = amnt;
    }

    public float GetDefaultSpeed()
    {
        return speed_default;
    }
}
