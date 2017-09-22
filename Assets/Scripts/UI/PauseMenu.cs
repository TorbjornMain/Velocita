using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PauseMenu : MonoBehaviour {

    int selectedIndex = 0;

    public RawImage[] buttonImages;
    public Vector3 buttonSelectedScale = new Vector3(1, 1.2f, 1);

	void OnEnable()
    {
        selectedIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < buttonImages.Length; i++)
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
        if (InputManager.ActiveDevice.LeftStick.Up.WasPressed)
        {
            selectedIndex = (selectedIndex - 1) < 0 ? (buttonImages.Length - 1) : (selectedIndex - 1);
        }
        if (InputManager.ActiveDevice.LeftStick.Down.WasPressed)
        {
            selectedIndex = (selectedIndex + 1) >= buttonImages.Length ? 0 : (selectedIndex + 1);
        }
        if(InputManager.ActiveDevice.Action1.WasPressed)
        {
            switch (selectedIndex)
            {
                case 0:
                    transform.parent.SendMessage("TogglePause");
                    break;
                case 1:

                    break;
                case 2:
                    transform.parent.SendMessage("TogglePause");
                    SceneNames.LoadScene(SceneNames.MainMenu);
                    break;
                default:
                    break;
            }

        }
    }
}
