using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MinimapCameraReplacement : MonoBehaviour {

    public Shader minimapShader;
    void OnEnable()
    {
        GetComponent<Camera>().SetReplacementShader(minimapShader, "Track");
    }
    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}
