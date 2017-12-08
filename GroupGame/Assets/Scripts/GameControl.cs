using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    private GameObject[] allPlayers;
	// Use this for initialization
	void Awake () {
		allPlayers = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(allPlayers.Length);
        SetPlayers(allPlayers);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetPlayers(GameObject[] p)
    {
        int i = 1;
        foreach(GameObject g in p)
        {
            PlayerControl pc = g.GetComponent<PlayerControl>();
            Debug.Log(i);
            pc.SetPlayerNumber(i);
            i++;
        }
    }
}
