using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

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
		
	}

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
