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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (mainMenuContainer.activeInHierarchy)
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
