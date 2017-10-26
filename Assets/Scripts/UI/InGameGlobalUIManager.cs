using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGlobalUIManager : MonoBehaviour {

    bool paused = false;
    bool canPause = true;
    public GameObject pauseUIContainer;
    public GameObject resultsUIContainer;
    public float pausedMusicVolume = 0.6f;
    public float playMusicVolume = 1.0f;
	// Use this for initialization
	void Start () {
		
	}

    void TogglePause()
    {
        if (canPause)
        {
            paused = !paused;
            MainMusic.musicVolume = paused ? pausedMusicVolume : playMusicVolume;
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
