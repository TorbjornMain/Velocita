using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PauseMenu : MonoBehaviour {

    int selectedIndex = 0;

    public RawImage[] buttonImages;
    public Vector3 buttonSelectedScale = new Vector3(1, 1.2f, 1);
    public AudioSource audioSourceReference;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip navigateSound;
    public AudioClip choiceSound;
    public GameObject quitContainer;
    public Image[] quitButtons;
    public GameObject settingsContainer;
    public Image[] settingsImages;
    public Slider[] settingsSliders;
    bool quitMode = false;
    bool settingsMode = false;

	void OnEnable()
    {
        selectedIndex = 0;
        audioSourceReference.clip = openSound;
        audioSourceReference.Play();
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
            for (int i = 0; i < buttonImages.Length; i++)
            {
                if (i == selectedIndex)
                {
                    buttonImages[i].rectTransform.localScale = buttonSelectedScale;
                }
                else
                {
                    buttonImages[i].rectTransform.localScale = Vector3.one;
                }
            }
            if (InputManager.ActiveDevice.LeftStick.Up.WasPressed || InputManager.ActiveDevice.DPadUp.WasPressed)
            {
                selectedIndex = (selectedIndex - 1) < 0 ? (buttonImages.Length - 1) : (selectedIndex - 1);
                audioSourceReference.clip = navigateSound;
                audioSourceReference.Play();
            }
            if (InputManager.ActiveDevice.LeftStick.Down.WasPressed || InputManager.ActiveDevice.DPadDown.WasPressed)
            {
                selectedIndex = (selectedIndex + 1) >= buttonImages.Length ? 0 : (selectedIndex + 1);
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
                        foreach (var item in buttonImages)
                        {
                            item.gameObject.SetActive(false);
                        }
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
            audioSourceReference.clip = navigateSound;
            audioSourceReference.Play();
        }
        if (InputManager.ActiveDevice.LeftStick.Down.Value > 0.5f || InputManager.ActiveDevice.DPadDown.WasPressed)
        {
            selectedIndex = (selectedIndex + 1) >= settingsImages.Length ? 0 : (selectedIndex + 1);
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
                    foreach (var item in buttonImages)
                    {
                        item.gameObject.SetActive(true);
                    }
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
            foreach (var item in buttonImages)
            {
                item.gameObject.SetActive(true);
            }
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
