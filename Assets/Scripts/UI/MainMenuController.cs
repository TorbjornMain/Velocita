using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public GameObject[] selectorNodes;
    public GameObject highlightPrefab;
    GameObject highlightInstance;
    public GameObject mainMenuContainer;
    public GameObject controllerAllocationContainer;

    void Start()
    {
        
    }

	// Update is called once per frame
	void Update ()
    {
        if (mainMenuContainer.activeInHierarchy)
        {
            if(highlightInstance == null) highlightInstance = Instantiate(highlightPrefab);
            highlightInstance.transform.position = selectorNodes[(int)selectedOption].transform.position;
            if (InputManager.ActiveDevice.LeftStick.Up.WasPressed)
            {
                selectedOption = (MenuOptions)(((int)selectedOption - 1) < 0 ? 3 : ((int)selectedOption - 1));
            }
            if (InputManager.ActiveDevice.LeftStick.Down.WasPressed)
            {
                selectedOption = (MenuOptions)(((int)selectedOption + 1) > 3 ? 0 : ((int)selectedOption + 1));
            }
            if (InputManager.ActiveDevice.Action1.WasPressed)
            {
                switch (selectedOption)
                {
                    case MenuOptions.Multiplayer:
                        mainMenuContainer.SetActive(false);
                        highlightInstance.SetActive(false);
                        controllerAllocationContainer.SetActive(true);
                        FindObjectOfType<ControllerManager>().AcquirePlayers = true;
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
