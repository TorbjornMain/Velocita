using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	// Use this for initialization
	void Start () {
        SceneNames.LoadScene(SceneNames.MainMenu);
	}
}
