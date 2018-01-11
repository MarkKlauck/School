using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingText : MonoBehaviour {
    private Text creditText;

    public float offset = 0.5f;
    // Use this for initialization
    void Start()
    {
        creditText = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        creditText.rectTransform.anchoredPosition = new Vector2(creditText.rectTransform.anchoredPosition.x, creditText.rectTransform.anchoredPosition.y + offset);
    }
}
