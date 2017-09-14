using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public string MenuScene = "MainMenuTest";
	// Use this for initialization
	void Start () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MenuScene);
	}
}
