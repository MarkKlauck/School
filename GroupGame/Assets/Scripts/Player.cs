using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int hp, maxhp, damage;
    //public Camera Cam;
    //collision stuff here?

    // Use this for initialization
    void Start() {
        SetMaxHP(100);
        SetHp(100);
        SetDamage(40);
    }

    // Update is called once per frame
    void Update() {
      //  CamDelay();
    }
    //use to set hp to a specified amount
    public void SetHp(int amnt)
    {
        hp = amnt;
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetMaxHP(int amnt)
    {
        maxhp = amnt;
    }

    public int GetMaxHP()
    {
        return maxhp;
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

   /* void CamDelay()
    {
       // Camera Cam = GetComponentInChildren<Camera>();
        Debug.Log(Cam.gameObject.name);
        Vector3 MoveCamTo = transform.position - transform.forward * 15f + Vector3.up * 20f;
        float bias = 0.97f;
        Cam.transform.position = Cam.transform.position * bias +
                                         MoveCamTo * (1.0f - bias);
        Cam.transform.LookAt(transform.position + transform.forward * 25f);
    }
    */
}
