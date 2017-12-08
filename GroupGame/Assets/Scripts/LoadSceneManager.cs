using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

    public UnityEngine.UI.Image panel;

    public float fade_time = 2.0f;
    float overIntensity = 1.0f;
    bool fade_start;
    string nextSceneName;
    // Use this for initialization
    public static LoadSceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LoadSceneManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("LoadSceneManager");
                    instance = go.AddComponent<LoadSceneManager>();

                }
            }

            return instance;
        }
    }


    private static LoadSceneManager instance = null;


   public static LoadSceneManager GetInstance()
    {
        return Instance;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(fade_start)
        {
            overIntensity = Mathf.Min(1.0f, overIntensity + Time.deltaTime / fade_time);

            if(overIntensity >= 1.0f)
            {
                LoadScene(nextSceneName);
            }
        }
        else
        {
            overIntensity = Mathf.Max(0.0f, overIntensity - Time.deltaTime / fade_time);
        }

        panel.color = new Color(1, 1, 1, overIntensity);

    }


    public void LoadSceneByButton(string name)
    {
        fade_start = true;
        nextSceneName = name;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
