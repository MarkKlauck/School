﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAsync : MonoBehaviour {

    private static string next_scene_name = "";
    private float fTime;
    private float screen_width;
    private float image_offsetX = 25f;
    private float image_offsetY = -15f;
    public Image Background_Image;
    public Sprite[] images;
    public Image loading_screen_image;
    public Image loading_screen_bar;
    public Text loading_text;
    // Use this for initialization
    public CanvasScaler cScaler;
    
    public static void LoadScene(string nextSceneName)
    {
        next_scene_name = nextSceneName;
        SceneManager.LoadScene("Loading");
    }
    void Start () {
        screen_width = cScaler.referenceResolution.x - 50;

        loading_screen_image.rectTransform.anchoredPosition = new Vector2(image_offsetX, image_offsetY);
        loading_screen_bar.fillAmount = 0;
        loading_text.text = "0%";

        Background_Image.sprite = images[Random.Range(0, images.Length)];
        StartCoroutine(IE_NextLoadScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    IEnumerator IE_NextLoadScene()
    {
        yield return null;

        AsyncOperation async_op = SceneManager.LoadSceneAsync(next_scene_name);
        async_op.allowSceneActivation = false;

        fTime = 0f;

        while(async_op.isDone == false)
        {
            yield return new WaitForSeconds(0.1f);
            fTime += Time.smoothDeltaTime;

            if(async_op.progress >= 0.9f)
            {
                //fill image
                loading_screen_bar.fillAmount = Mathf.Lerp(loading_screen_bar.fillAmount, 1f, fTime);

                //25 offset ( half size of image )
                float scr_pos_x = (loading_screen_bar.fillAmount * screen_width) + image_offsetX;
                loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                Debug.Log(loading_screen_image.rectTransform.anchoredPosition);

                float progress_num = loading_screen_bar.fillAmount * 100.0f;
                int roundNum = Mathf.RoundToInt(progress_num);

                loading_text.text = roundNum.ToString() + "%";

                if (Mathf.Approximately(loading_screen_bar.fillAmount, 1f) == true)
                {
                    async_op.allowSceneActivation = true;
                }
            }
            else
            {
                loading_screen_bar.fillAmount = Mathf.Lerp(loading_screen_bar.fillAmount, async_op.progress, fTime);
              
                //25 offset ( half size of image )
                float scr_pos_x = (loading_screen_bar.fillAmount * screen_width) + image_offsetX;
                loading_screen_image.rectTransform.anchoredPosition = new Vector2(scr_pos_x, image_offsetY);
                Debug.Log(loading_screen_image.rectTransform.anchoredPosition);
                float progress_num_ = loading_screen_bar.fillAmount * 100.0f;
                int round_progress_num = Mathf.RoundToInt(progress_num_);
                loading_text.text = round_progress_num.ToString() + "%";

                if (loading_screen_bar.fillAmount >= async_op.progress)
                {
                    fTime = 0f;
                }
            }
        }
    }
}