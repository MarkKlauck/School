using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip[] ac;
    // Use this for initialization
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("SoundManager");
                    instance = go.AddComponent<SoundManager>();
                    audioSource = go.AddComponent<AudioSource>();
                }
            }

            return instance;
        }
    }


    private static SoundManager instance = null;
    private static AudioSource audioSource;


    void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayBackgroundMusic(AudioClip backgroundMusic)
    {
        if (audioSource.isPlaying == true)
            audioSource.Stop();

        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    public void ChangeBackgroundMusic(AudioClip music)
    {
        PlayBackgroundMusic(music);
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        
    }
}
