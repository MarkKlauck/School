using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BloodImage : MonoBehaviour {

    public Player player;
    public float fade_start_percent = 0.2f;
    public bool blood_start = false;
    private Image image;
    public float fPercent = 1.0f;
    public float fade_accel = 3.0f;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(blood_start)
        {
           // float fPercent = (float)player.GetHP() / (float)player.GetMaxHP();
            if(fPercent <= fade_start_percent)
            {
                float alpha;
                if (fPercent == 0.0f)
                {
                    alpha = 1.0f;
                }
                else
                {
                    // 5 steps
                    // 20% -> 15% -> 10% -> 5% -> 0
                    //  1  ->  2  ->  3  -> 4  -> 5 times
                    float fade_step = ((fade_start_percent - fPercent) / 0.05f) + 1.0f;
                    float fade_speed = Mathf.Pow(fade_accel, fade_step);
                    alpha = (Mathf.Sin(Time.time * fade_speed) * 0.5f + 0.5f);
                }
               
                image.color = new Color(1, 1, 1, alpha);
            }
            else
            {
                blood_start = false;
                image.color = new Color(1, 1, 1, 0);
            }
           
        }
        
	}

}
