using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlinkingText : MonoBehaviour {

    // Use this for initialization
    Image panel;
	void Start () {
        panel = GetComponent<Image>();
        StartBlinking();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartBlinking()
    {
        StopCoroutine(Blink());
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while(true)
        {
            float alphaVal = panel.color.a;
            if(Mathf.Approximately(alphaVal, 1.0f))
            {
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
                yield return new WaitForSeconds(0.5f);
            }
            else if (Mathf.Approximately(alphaVal, 0.0f))
            {
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
