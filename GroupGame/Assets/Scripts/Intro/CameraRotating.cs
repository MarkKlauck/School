using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
    public float rotating_speed = 5.0f;
    public UnityEngine.UI.Button[] btns;
    int selectedIndex = 0;
    void Start () {
        selectedIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.right * Time.deltaTime * rotating_speed);


        checkButtonState();
        btns[selectedIndex].targetGraphic.CrossFadeColor(btns[selectedIndex].colors.highlightedColor, 0.1f, true, false);
     
        foreach(UnityEngine.UI.Button bt in btns)
        {
            bt.targetGraphic.CrossFadeColor(btns[selectedIndex].colors.normalColor, 0.1f, true, false);
        }
    }

    private void checkButtonState()
    {
        if(Input.GetAxis("Player1 Dpad Y") < 0.0f)
        {
            selectedIndex = Mathf.Min(btns.Length - 1, ++selectedIndex);
        }
        else if (Input.GetAxis("Player1 Dpad Y") > 0.0f)
        {
            selectedIndex = Mathf.Max(btns.Length - 1, --selectedIndex);
        }
    }

    private bool IsSelectButtonPressed()
    {
        return (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button7));
    }
}
