using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {
    private LobbyScript lb;
	// Use this for initialization
	void Start () {
        lb = GameObject.Find("LobbyManager").GetComponent<LobbyScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick(int index)
    {
        lb.AddPlayer(index);
        gameObject.SetActive(false);
    }
}
