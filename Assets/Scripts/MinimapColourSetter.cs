using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapColourSetter : MonoBehaviour {

    public Color minimapColor;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.SetColor("_MinimapColor", minimapColor);	
	}
	
	
}
