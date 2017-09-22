using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGlobalUIManager : MonoBehaviour {

    bool paused = false;
    bool canPause = true;
    public GameObject pauseUIContainer;
    public GameObject resultsUIContainer;
	// Use this for initialization
	void Start () {
		
	}

    void TogglePause()
    {
        if (canPause)
        {
            paused = !paused;
            pauseUIContainer.SetActive(paused);
            Time.timeScale = paused ? 0 : 1;
        }
    }

    void DisplayResults()
    {
        pauseUIContainer.SetActive(false);
        resultsUIContainer.SetActive(true);
        paused = false;
        Time.timeScale = 1;
        canPause = false;
    }

}
