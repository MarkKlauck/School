using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance = null;

    public int imageMaxWidth = 400;
    [HideInInspector]
    public GameObject player1Hp, player2Hp, player3Hp, player4Hp;
	// Use this for initialization
	void Start () {
		if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(this);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private GameObject GetObect(string name)
    {
        switch(name)
        {
            case "player1":
                {
                    return player1Hp;
                }
            case "player2":
                {
                    return player2Hp;
                }
            case "player3":
                {
                    return player3Hp;
                }
            case "player4":
                {
                    return player4Hp;
                }
            default:
                {
                    return null;
                }
        }
    }
    public void SetHealthBar(float curHp, float maxHp, string name)
    {
        GameObject g = GetObect(name);
        Image i = g.GetComponent<Image>();
        int offset = (int)(imageMaxWidth / maxHp);
        int width = (int)curHp * offset;
        i.rectTransform.sizeDelta = new Vector2(width, 25);
    }
}
