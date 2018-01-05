using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public bool m_cameraShake = false;
    
    public float default_shake_duration = 1.2f;
    private float shake_duration =0f;
    public float shake_amount = 0.7f;
    public float decrease_factor = 1.0f;
    // Use this for initialization
    Vector3 origin_pos;
    void Start ()
    {
        shake_duration = default_shake_duration;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShakeCamera();

	    if(m_cameraShake)
        {
            if(shake_duration > 0.0f)
            {
                transform.localPosition = origin_pos + Random.insideUnitSphere * shake_amount;
                shake_duration -= decrease_factor * Time.deltaTime;
            }
            else
            {
                shake_duration = 0f;
                transform.localPosition = origin_pos;
                m_cameraShake = false;
            }
            
        }
	}


    public void ShakeCamera()
    {
        m_cameraShake = true;
        origin_pos = transform.localPosition;
        shake_duration = default_shake_duration;
    }
}
