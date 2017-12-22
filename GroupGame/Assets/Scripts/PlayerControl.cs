using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float moveSpeed;

    private Animator anim;
    private int controllers;
    private int playerNum;
    private int joyNum;
    public string axis;
    public string axisx;
    private float nextClick = 0.0f;
    private float nextLight = 0.0f;
    private float delay = 1.0f;
    private float lightDelay = 0.6f;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //playerNum = GetPlayerNumber();
        joyNum = GetJoystickNumber();
        axis = "Joystick" + joyNum + " Lefty";
        axisx = "Joystick" + joyNum + " Leftx";

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("joystick " + joyNum + " button 2") && Time.time > nextLight)// && anim.GetCurrentAnimatorStateInfo(0).
        {
            int r = Random.Range(0, 3);
            if (r == 0)
            {
                anim.SetTrigger("IsLightAttack");
            }
            else if (r == 1)
            {
                anim.SetTrigger("IsLightAttack2");
            }
            else if (r == 2)
            {
                anim.SetTrigger("IsLightAttack3");
            }
            nextClick = Time.time + delay;
            nextLight = Time.time + lightDelay;

        }
        if (Input.GetKeyDown("joystick " + joyNum + " button 3") && Time.time > nextClick)// && anim.GetCurrentAnimatorStateInfo(0).
        {
            int r = Random.Range(0, 3);
            if (r == 0)
            {
                anim.SetTrigger("IsHeavyAttack");
            }
            else if (r == 1)
            {
                anim.SetTrigger("IsHeavyAttack2");
            }
            else if (r == 2)
            {
                anim.SetTrigger("IsHeavyAttack3");
            }
            nextClick = Time.time + delay;
            nextLight = Time.time + lightDelay;

        }
        if (Input.GetKeyDown("joystick " + joyNum + " button 1") && Time.time > nextClick)// && anim.GetCurrentAnimatorStateInfo(0).
        {
            anim.SetTrigger("IsRolling");
            nextClick = Time.time + delay;
            nextLight = Time.time + lightDelay;

        }
        if (Input.GetKeyDown("joystick " + joyNum + " button 5") && Time.time > nextClick)// && anim.GetCurrentAnimatorStateInfo(0).
        {
            anim.SetTrigger("IsMagicLight");
            nextClick = Time.time + delay;
            nextLight = Time.time + lightDelay;

        }
        if (Input.GetKeyDown("joystick " + joyNum + " button 4") && Time.time > nextClick)// && anim.GetCurrentAnimatorStateInfo(0).
        {
            anim.SetTrigger("IsMagicHeavy");
            nextClick = Time.time + delay;
            nextLight = Time.time + lightDelay;

        }

        /*
        Vector3 movement = new Vector3(Input.GetAxis(axisx), 0.0f, -Input.GetAxis(axis));
        transform.Translate(movement * Time.deltaTime * moveSpeed);*/

        #region for debugging controller input
        /*for (int i = 1; i <= 16; i++)
        {
            string key = "joystick " + i + " button " + 0;
            for (int j = 0; j < 20; j++)
            {
                key = "joystick " + i + " button " + j;
                if (Input.GetKeyDown(key))
                {
                    Debug.Log(key);
                }
            }
        }*/
        #endregion

    }

    public int GetPlayerNumber()
    {
        return playerNum;
    }
    public void SetPlayerNumber(int n)
    {
        playerNum = n;
    }
    public int GetJoystickNumber()
    {
        return PlayerPrefs.GetInt("player" + playerNum);
    }
    private int CountControllers()
    {
        string[] names = Input.GetJoystickNames();
        int count = 0;
        foreach (string n in names)
        {
            if (n != "Wireless Controller")
            {
                count++;
                Debug.Log(n + "\n");
            }

        }

        return count;
    }
}
