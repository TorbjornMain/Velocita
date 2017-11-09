using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScreen : MonoBehaviour {
    ControllerManager cm;

    public SelectorObject selectorPrefab;

    List<SelectorObject> selectorInstances = new List<SelectorObject>();

    [Tooltip("Laid out as P1Red P2Red P3Red P4Red P1Blue P2Blue...")]
    public List<Transform> selectorNodes;
    public Image[] characterPortraits;
    public Image[] playerZones;
    public Color[] playerColors;
    public Text[] playerJoinText;
    bool[] selected;
    public float playerXOffset = 40;
    public string gameScene;
    AudioSource audioSource;
    public AudioClip navigateSound;
    public AudioClip selectSound;
    public AudioClip cancelSound;
    public AudioClip invalidChoiceSound;
    public GameObject selectedBar;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        cm = FindObjectOfType<ControllerManager>();
        cm.players.Clear();
        FindObjectOfType<ControllerManager>().AcquirePlayers = true;
        selected = new bool[selectorNodes.Count];
        for(int i = 0; i < 4; i++)
        {
            SelectorObject si = Instantiate<SelectorObject>(selectorPrefab);
            si.playerIndex = i;
            si.transform.SetParent(transform);
            si.gameObject.SetActive(false);
            selectorInstances.Add(si);
        }
	}
	
	// Update is called once per frame
	void Update () {


        bool allSelected = cm.players.Count > 0;
        for (int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].hasSelected)
            {
                allSelected = false;
                break;
            }
        }
        if (allSelected)
        {
            if (InControl.InputManager.ActiveDevice.Action1.WasPressed)
            {
                FindObjectOfType<ControllerManager>().AcquirePlayers = false;
                SceneNames.LoadScene(gameScene);
            }
        }
        selectedBar.SetActive(allSelected);

        if (cm.players.Count == 0 && InControl.InputManager.ActiveDevice.Action2.WasPressed)
        {
            SceneNames.LoadScene(SceneNames.MainMenu);
        }

        for (int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].gameObject.activeInHierarchy)
            {
                selectorInstances[i].gameObject.SetActive(true);
                playerJoinText[i].text = "P" + (i + 1).ToString();
            }
            else
            {
                selectorInstances[i].transform.position = selectorNodes[selectorInstances[i].hoveredIndex * 4 + i].position;

                if (cm.players[i].ind.Action2.WasPressed)
                {
                    if (!selected[selectorInstances[i].hoveredIndex] && selectorInstances[i].hasSelected)
                    {
                        SceneNames.LoadScene(SceneNames.MainMenu);
                    }
                    else
                    {
                        PControlData playerData = cm.players[i];
                        playerData.col = RacerColor.White;
                        playerZones[i].color = Color.white;
                        characterPortraits[i].color = Color.white;

                        cm.players[i] = playerData;
                        selectorInstances[i].hasSelected = false;
                        selected[selectorInstances[i].hoveredIndex] = false;
                        audioSource.clip = cancelSound;
                        audioSource.Play();
                    }
                }

                if (!selectorInstances[i].hasSelected)
                {
                    if (cm.players[i].ind.Action1.WasPressed)
                    {
                        if (!selected[selectorInstances[i].hoveredIndex])
                        {
                            selected[selectorInstances[i].hoveredIndex] = true;
                            PControlData playerData = cm.players[i];
                            playerData.col = ((RacerColor)selectorInstances[i].hoveredIndex);
                            playerZones[i].color = playerColors[selectorInstances[i].hoveredIndex];
                            characterPortraits[i].color = Color.grey;

                            cm.players[i] = playerData;
                            selectorInstances[i].hasSelected = true;
                            audioSource.clip = selectSound;
                            audioSource.Play();
                        }
                        else
                        {
                            audioSource.clip = invalidChoiceSound;
                            audioSource.Play();
                        }
                    }


                    if (!selectorInstances[i].hasSelected)
                    {
                        if (cm.players[i].ind.LeftStick.Left.WasPressed || cm.players[i].ind.DPadLeft.WasPressed)
                        {
                            selectorInstances[i].hoveredIndex = selectorInstances[i].hoveredIndex - 1 < 0 ? 3 : selectorInstances[i].hoveredIndex - 1;
                            audioSource.clip = navigateSound;
                            audioSource.Play();
                        }

                        if (cm.players[i].ind.LeftStick.Right.WasPressed || cm.players[i].ind.DPadRight.WasPressed)
                        {
                            selectorInstances[i].hoveredIndex = selectorInstances[i].hoveredIndex + 1 > 3 ? 0 : selectorInstances[i].hoveredIndex + 1;
                            audioSource.clip = navigateSound;
                            audioSource.Play();
                        }
                    }
                }
            }
        }
        
	}

}
