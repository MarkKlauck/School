using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
    //public Image[] images;
    public Button[] buttons;
    public RawImage imgPrefab;
    //public Button btnPrefab;

    public Camera[] character_cams;
    public GameObject[] characters;
    private int playerNum = 1;

    private float newWidth = Screen.width / 2 - 10;
    private float newHeight = Screen.height / 2 - 10;
    private List<int> nums;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("player1", 0);
        nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, };// 12, 13, 14, 15, 16 };
        SetScene();
    }

    // Update is called once per frame
    void Update()
    {

        // need to configure input manager to reflect player joy number
        // modify cam script to take player joy number instead of player number

        for (int i = 0; i < nums.Count; i++)
        {
            string key = "joystick " + nums[i] + " button " + 0;
            if (Input.GetKeyDown(key))
            {
                string name = "player" + playerNum;
                PlayerPrefs.SetInt(name, nums[i]);
                nums.RemoveAt(i);
                buttons[playerNum - 1].gameObject.SetActive(false);
                AddPlayer(i);
                i = 0;
                //SoundManager.Instance.PlaySound(audioClips[]);
                break;
            }
        }
        if (PlayerPrefs.GetInt("player1") != 0)
        {
            if (Input.GetKey("joystick " + PlayerPrefs.GetInt("player1") + " button 7"))
            {
                LoadSceneManager lsm = GameObject.Find("start game").GetComponent<LoadSceneManager>();
                lsm.LoadSceneByButton("Main");
            }
        }
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
        for (int i = 0; i < 4; i++)
        {
            GameObject canv = GameObject.Find("Canvas");
            RawImage img = Instantiate(imgPrefab, bkgLoc[i], Quaternion.identity) as RawImage;
            img.transform.SetParent(GameObject.Find("BKGPanels").transform);
            img.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
            img.rectTransform.anchoredPosition = bkgLoc[i];
            buttons[i].gameObject.SetActive(true);


            RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
            rt.Create();
            character_cams[i].targetTexture = rt;
            img.texture = rt;

        }
    }

    public void AddPlayer(int character_index)
    {
        PlayerPrefs.SetInt("PlayerCount", playerNum);
        playerNum++;

        characters[character_index].GetComponent<Animator>().SetTrigger("Select");
    }
}
