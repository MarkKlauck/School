using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public int players;
    public Text[] plyrScore;
    public Rect[] camPos;
    public GameObject[] allPlayers;
    public GameObject[] plyrSpawns;
	// Use this for initialization
	void Awake () {
        plyrScore[0].enabled = false;
        plyrScore[1].enabled = false;
        plyrScore[2].enabled = false;
        plyrScore[3].enabled = false;
        SetScoreHUD();
        //SetPlayers();
        SetGame();
        /*
		allPlayers = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(allPlayers.Length);*/
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGame()
    {
        if (players == 2)
        {
            Rect[] newRect = { new Rect(0, 0.5f, 0.75f, 0.499f), new Rect(0.25f, 0, 0.75f, 0.499f) };
            for (int i = 0; i < players; i++)
            {

                GameObject currentPlayer = Instantiate(allPlayers[i], plyrSpawns[i].transform.position, Quaternion.identity) as GameObject;
                Camera plyrCam = currentPlayer.GetComponentInChildren<Camera>();
                plyrCam.rect = newRect[i];
                PlayerControl pc = currentPlayer.GetComponent<PlayerControl>();
                pc.SetPlayerNumber(i + 1);
            }
        }
        else if (players == 1)
        {
            for (int i = 0; i < players; i++)
            {

                GameObject currentPlayer = Instantiate(allPlayers[i], plyrSpawns[i].transform.position, Quaternion.identity) as GameObject;
                PlayerControl pc = currentPlayer.GetComponent<PlayerControl>();
                pc.SetPlayerNumber(i + 1);
            }
        }
        else
        {
            for (int i = 0; i < players; i++)
            {
                GameObject currentPlayer = Instantiate(allPlayers[i], plyrSpawns[i].transform.position, Quaternion.identity) as GameObject;
                Camera plyrCam = currentPlayer.GetComponentInChildren<Camera>();
                plyrCam.rect = camPos[i];
                PlayerControl pc = currentPlayer.GetComponent<PlayerControl>();
                pc.SetPlayerNumber(i + 1);
            }
        }
    }

    void SetScoreHUD()
    {
        if(players == 1)
        {
            plyrScore[0].rectTransform.anchoredPosition = new Vector2(10, Screen.height - 30);
            plyrScore[0].enabled = true;
        }
        else if (players == 2)
        {
            Vector2[] scorePos = 
            {
                new Vector2(10, Screen.height - 30),
                new Vector2(Screen.width/4 + 10, Screen.height / 2 - 30)
            };
            for(int x = 0; x < 2;x++)
            {
                plyrScore[x].rectTransform.anchoredPosition = scorePos[x];
                plyrScore[x].enabled = true;
            }
            
        }
        else if (players == 3)
        {
            Vector2[] scorePos = 
            {
                new Vector2(10, Screen.height - 30),
                new Vector2(Screen.width / 2 + 10, Screen.height - 30),
                new Vector2(10, Screen.height/2 - 30)
            };
            for (int x = 0; x < 3; x++)
            {
                plyrScore[x].rectTransform.anchoredPosition = scorePos[x];
                plyrScore[x].enabled = true;
            }

        }
        else
        {
            Vector2[] scorePos = 
            {
                new Vector2(10, Screen.height - 30),
                new Vector2(Screen.width / 2 + 10, Screen.height - 30),
                new Vector2(10, Screen.height / 2 - 30),
                new Vector2 (Screen.width / 2 + 10, Screen.height / 2 - 30)
            };
            for (int x = 0; x < 4; x++)
            {
                plyrScore[x].rectTransform.anchoredPosition = scorePos[x];
                plyrScore[x].enabled = true;
            }
        }
    }
    /*
    public void SetPlayers()
    {
        int i = 1;
        for(int a = 0;a<players;a++)
        {
            Debug.Log(i);
            PlayerControl pc = allPlayers[a].GetComponent<PlayerControl>();
            pc.SetPlayerNumber(i);
            Debug.Log(pc.GetPlayerNumber());
            i++;
        }
    }*/
}
