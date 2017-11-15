using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PauseMenu : MonoBehaviour {

    int selectedIndex = 0;

    public GameObject[] selectorNodes;
    public AudioSource audioSourceReference;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip navigateSound;
    public AudioClip choiceSound;
    public GameObject quitContainer;
    public Image[] quitButtons;
    public GameObject settingsContainer;
    public GameObject[] settingsNodes;
    public Slider[] settingsSliders;
    public GameObject menuCursor;
    public GameObject settingsCursor;
    bool quitMode = false;
    bool settingsMode = false;

	void OnEnable()
    {
        selectedIndex = 0;
        quitMode = false;
        settingsMode = false;
        audioSourceReference.clip = openSound;
        audioSourceReference.Play();
        PlayerPrefs.Save();
    }

    void OnDisable()
    {
        audioSourceReference.clip = closeSound;
        audioSourceReference.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (quitMode)
        {
            QuitMode();
        }
        else if(settingsMode)
        {
            SettingsMode();
        }
        else
        {

            menuCursor.transform.position = selectorNodes[selectedIndex].transform.position;
            if (InputManager.ActiveDevice.LeftStick.Up.WasPressed || InputManager.ActiveDevice.DPadUp.WasPressed)
            {
                selectedIndex = (selectedIndex - 1) < 0 ? (selectorNodes.Length - 1) : (selectedIndex - 1);
                audioSourceReference.clip = navigateSound;
                audioSourceReference.Play();
            }
            if (InputManager.ActiveDevice.LeftStick.Down.WasPressed || InputManager.ActiveDevice.DPadDown.WasPressed)
            {
                selectedIndex = (selectedIndex + 1) >= selectorNodes.Length ? 0 : (selectedIndex + 1);
                audioSourceReference.clip = navigateSound;
                audioSourceReference.Play();
            }
            if (InputManager.ActiveDevice.Action1.WasPressed)
            {
                switch (selectedIndex)
                {
                    case 0:
                        transform.parent.SendMessage("TogglePause");
                        break;
                    case 1:
                        audioSourceReference.clip = choiceSound;
                        audioSourceReference.Play();
                        settingsMode = true;
                        selectedIndex = 0;
                        settingsContainer.SetActive(true);
                        break;
                    case 2:
                        audioSourceReference.clip = choiceSound;
                        audioSourceReference.Play();

                        quitMode = true;

                        selectedIndex = 1;
                        quitContainer.SetActive(true);

                        break;
                    default:
                        break;
                }

            }
            if (InputManager.ActiveDevice.Action2.WasPressed)
            {
                transform.parent.SendMessage("TogglePause");
            }
        }
    }



    void SettingsMode()
    {
        settingsCursor.transform.position = settingsNodes[selectedIndex].transform.position;
        settingsSliders[0].value = MainMusic.musicSetting;
        settingsSliders[1].value = MainMusic.soundSetting;
        if (InputManager.ActiveDevice.LeftStick.Up.Value > 0.5f || InputManager.ActiveDevice.DPadUp.WasPressed)
        {
            selectedIndex = (selectedIndex - 1) < 0 ? (settingsNodes.Length - 1) : (selectedIndex - 1);
            audioSourceReference.clip = navigateSound;
            audioSourceReference.Play();
        }
        if (InputManager.ActiveDevice.LeftStick.Down.Value > 0.5f || InputManager.ActiveDevice.DPadDown.WasPressed)
        {
            selectedIndex = (selectedIndex + 1) >= settingsNodes.Length ? 0 : (selectedIndex + 1);
            audioSourceReference.clip = navigateSound;
            audioSourceReference.Play();
        }

        if (InputManager.ActiveDevice.LeftStick.Left.Value > 0.5f || InputManager.ActiveDevice.DPadLeft.WasPressed)
        {
            switch (selectedIndex)
            {
                case 0:
                    MainMusic.musicSetting = Mathf.Clamp01(MainMusic.musicSetting - 0.1f);
                    break;
                case 1:
                    MainMusic.soundSetting = Mathf.Clamp01(MainMusic.soundSetting - 0.1f);
                    break;
                default:
                    break;
            }

        }

        if (InputManager.ActiveDevice.LeftStick.Right.Value > 0.5f || InputManager.ActiveDevice.DPadRight.WasPressed)
        {
            switch (selectedIndex)
            {
                case 0:
                    MainMusic.musicSetting = Mathf.Clamp01(MainMusic.musicSetting + 0.1f);
                    break;
                case 1:
                    MainMusic.soundSetting = Mathf.Clamp01(MainMusic.soundSetting + 0.1f);
                    break;
                default:
                    break;
            }
        }

            if (InputManager.ActiveDevice.Action2.WasPressed)
        {
            settingsMode = false;
            selectedIndex = 1;
            settingsContainer.SetActive(false);
        }
    }




    void QuitMode()
    {
        if (InputManager.ActiveDevice.LeftStick.Left.WasPressed || InputManager.ActiveDevice.DPadLeft.WasPressed)
        {
            selectedIndex = (selectedIndex - 1) < 0 ? (quitButtons.Length - 1) : (selectedIndex - 1);
            audioSourceReference.clip = navigateSound;
            audioSourceReference.Play();
        }
        if (InputManager.ActiveDevice.LeftStick.Right.WasPressed || InputManager.ActiveDevice.DPadRight.WasPressed)
        {
            selectedIndex = (selectedIndex + 1) >= quitButtons.Length ? 0 : (selectedIndex + 1);
            audioSourceReference.clip = navigateSound;
            audioSourceReference.Play();
        }

        if (InputManager.ActiveDevice.Action1.WasPressed)
        {
            switch (selectedIndex)
            {
                case 0:
                    transform.parent.SendMessage("TogglePause");
                    SceneNames.LoadScene(SceneNames.MainMenu);
                    break;
                case 1:
                    quitContainer.SetActive(false);
                    quitMode = false;
                    break;
                default:
                    break;
            }

        }
        if (InputManager.ActiveDevice.Action2.WasPressed)
        {
            selectedIndex = 2;
            quitContainer.SetActive(false);
            quitMode = false;
        }
        for (int i = 0; i < quitButtons.Length; i++)
        {
            if (i == selectedIndex)
            {
                quitButtons[i].color = Color.red;
            }
            else
            {
                quitButtons[i].color = Color.black;
            }
        }
    }
}
