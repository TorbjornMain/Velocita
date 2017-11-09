using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class TutorialScreen : MonoBehaviour {

    public Image[] tutorialScreens;
    int currentScreen = 0;
	
	// Update is called once per frame
	void Update () {
        if (currentScreen >= tutorialScreens.Length) SceneNames.LoadScene("Jess Test");
		for(int i = 0; i < tutorialScreens.Length; i++)
        {
            if (i == currentScreen)
                tutorialScreens[i].enabled = true;
            else
                tutorialScreens[i].enabled = false;
        }
        if(InputManager.ActiveDevice.Action1.WasPressed)
        {
            currentScreen++;
        }
	}
}
