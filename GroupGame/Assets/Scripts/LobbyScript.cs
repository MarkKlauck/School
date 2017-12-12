using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour {
    public Image[] images;
    public Button[] buttons;

    private int playerNum = 0;
    // Use this for initialization
    void Start () {
        SetScene();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetScene()
    {
        Vector2[] bkgLoc =
        {
            new Vector2(0, Screen.height/2),
            new Vector2(Screen.width/2, Screen.height/2),
            new Vector2(0, 0),
            new Vector2(Screen.width/2, 0),
        };
        for(int i = 0;i<4;i++)
        {
            float newWidth = Screen.width / 2 - 10;
            float newHeight = Screen.height / 2 - 10;
            images[i].rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
            images[i].rectTransform.anchoredPosition = bkgLoc[i];
        }
    }

    public void AddPlayer()
    {
        playerNum++;
        PlayerPrefs.SetInt("PlayerCount", playerNum);
        Debug.Log(playerNum);
    }
}
