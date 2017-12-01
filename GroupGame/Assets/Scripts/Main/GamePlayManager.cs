using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadSceneManager.Instance.LoadScene("Lobby");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
