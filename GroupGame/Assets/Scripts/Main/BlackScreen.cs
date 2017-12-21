using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour {

    private float intensity = 0.0f;
    private Material mat;

    private void Awake()
    {
        mat = new Material(Shader.Find("Hidden/Monotone"));
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(intensity == 0.0f)
        {
            Graphics.Blit(source, destination);
        }
        else
        {
            mat.SetFloat("_bwBlend", intensity);
            Graphics.Blit(source, destination, mat);
        }
        
    }

    public void TurnOnBlackScreen()
    {
        intensity = 1.0f;
    }
    public void TurnOffBlackScreen()
    {
        intensity = 0.0f;
    }
}
