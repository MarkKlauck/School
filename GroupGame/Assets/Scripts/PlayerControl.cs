using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private int controllers;
    private int playerNum;
    private int joyNum;
    string axis;
    string axisx;
    // Use this for initialization
    void Start () {
        //playerNum = GetPlayerNumber();
        joyNum = GetJoystickNumber();
        axis = "Joystick" + joyNum + " Lefty";
        axisx = "Joystick" + joyNum + " Leftx";

    }

    // Update is called once per frame
    void Update () {
        Vector3 movement = new Vector3(Input.GetAxis(axisx), 0.0f, -Input.GetAxis(axis));
        transform.Translate(movement * 5.0f * Time.deltaTime);

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
