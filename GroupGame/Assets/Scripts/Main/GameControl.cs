using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int players;
    public Text[] plyrScore;
    public Rect[] camPos;
    public GameObject[] allPlayers;
    public GameObject[] plyrSpawns;

	// Use this for initialization
	void Awake () {
        SetPlayerCount();
        SetScoreHUD();
        SetGame();
    }

    void Start()
    {
        
    }
    
    void Update ()
    {
        
    }

    public void SetGame()
    {
        if (players == 1)
        {
            GameObject currentPlayer = Instantiate(allPlayers[0], plyrSpawns[0].transform.position, Quaternion.identity) as GameObject;
            PlayerControl pc = currentPlayer.GetComponent<PlayerControl>();
            pc.SetPlayerNumber(1);
        }
        else if (players == 2)
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

    public void SetPlayerCount()
    {
        players = PlayerPrefs.GetInt("PlayerCount", 1);
    }

    #region game setup stuff
    void SetScoreHUD()
    {
        if(players == 1)
        {
            plyrScore[0].rectTransform.anchoredPosition = new Vector2(10, Screen.height - 30);
            plyrScore[0].gameObject.SetActive(true);
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
                plyrScore[x].gameObject.SetActive(true);
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
                plyrScore[x].gameObject.SetActive(true);
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
                plyrScore[x].gameObject.SetActive(true);
            }
        }
    }
#endregion
}
