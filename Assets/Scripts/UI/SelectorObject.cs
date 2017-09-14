using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorObject : MonoBehaviour {

    [System.NonSerialized]
    public bool hasSelected = false;
    [System.NonSerialized]
    public int hoveredIndex = 0;
    [System.NonSerialized]
    public int playerIndex = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = (playerIndex + 1).ToString();
	}
}
