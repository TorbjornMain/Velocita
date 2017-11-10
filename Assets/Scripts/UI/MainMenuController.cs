using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

[System.Serializable]
public enum MenuOptions
{
    Multiplayer,
    TimeTrial,
    Settings,
    Quit
}

public class MainMenuController : MonoBehaviour {

    MenuOptions selectedOption = MenuOptions.Multiplayer;
    public Image[] selectorNodes;
    public GameObject mainMenuContainer;
    public GameObject controllerAllocationContainer;
    public Vector3 buttonSelectedScale;
    AudioSource audioSource;
    public AudioClip selectedClip;
    public AudioClip navigateClip;

    int selectedIndex = 0;
    public GameObject settingsContainer;
    public Image[] settingsImages;
    public Slider[] settingsSliders;
     bool settingsMode;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (mainMenuContainer.activeInHierarchy)
        {
            if (settingsMode)
                SettingsMode();
            else
            {
                for (int i = 0; i < selectorNodes.Length; i++)
                {
                    if (i == (int)selectedOption)
                    {
                        selectorNodes[i].rectTransform.localScale = buttonSelectedScale;
                    }
                    else
                    {
                        selectorNodes[i].rectTransform.localScale = Vector3.one;
                    }
                }

                if (InputManager.ActiveDevice.LeftStick.Up.WasPressed || InputManager.ActiveDevice.DPadUp.WasPressed)
                {
                    selectedOption = (MenuOptions)(((int)selectedOption - 1) < 0 ? 3 : ((int)selectedOption - 1));
                    audioSource.clip = navigateClip;
                    audioSource.Play();
                }
                if (InputManager.ActiveDevice.LeftStick.Down.WasPressed || InputManager.ActiveDevice.DPadDown.WasPressed)
                {
                    selectedOption = (MenuOptions)(((int)selectedOption + 1) > 3 ? 0 : ((int)selectedOption + 1));
                    audioSource.clip = navigateClip;
                    audioSource.Play();
                }
                if (InputManager.ActiveDevice.Action1.WasPressed)
                {
                    audioSource.clip = selectedClip;
                    audioSource.Play();
                    switch (selectedOption)
                    {
                        case MenuOptions.Multiplayer:
                            SceneNames.LoadScene(SceneNames.CharacterSelect);
                            break;
                        case MenuOptions.Settings:
                            settingsMode = true;
                            selectedIndex = 0;
                            settingsContainer.SetActive(true);
                            break;
                        case MenuOptions.Quit:
                            Application.Quit();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }


    void SettingsMode()
    {
        for (int i = 0; i < settingsImages.Length; i++)
        {
            if (i == selectedIndex)
            {
                settingsImages[i].rectTransform.localScale = buttonSelectedScale;
            }
            else
            {
                settingsImages[i].rectTransform.localScale = Vector3.one;
            }

        }
        settingsSliders[0].value = MainMusic.musicSetting;
        settingsSliders[1].value = MainMusic.soundSetting;
        if (InputManager.ActiveDevice.LeftStick.Up.Value > 0.5f || InputManager.ActiveDevice.DPadUp.WasPressed)
        {
            selectedIndex = (selectedIndex - 1) < 0 ? (settingsImages.Length - 1) : (selectedIndex - 1);
            audioSource.clip = navigateClip;
            audioSource.Play();
        }
        if (InputManager.ActiveDevice.LeftStick.Down.Value > 0.5f || InputManager.ActiveDevice.DPadDown.WasPressed)
        {
            selectedIndex = (selectedIndex + 1) >= settingsImages.Length ? 0 : (selectedIndex + 1);
            audioSource.clip = navigateClip;
            audioSource.Play();
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
            selectedIndex = 0;
            settingsContainer.SetActive(false);
        }
    }

}
