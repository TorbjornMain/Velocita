using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGlobalUIManager : MonoBehaviour {

    bool paused = false;
    public GameObject pauseUIContainer;
	// Use this for initialization
	void Start () {
		
	}

    void TogglePause()
    {
        paused = !paused;
        pauseUIContainer.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

}
