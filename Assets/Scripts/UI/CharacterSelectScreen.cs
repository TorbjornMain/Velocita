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
    public Image[] playerZones;
    public Color[] playerColors;
    public Text[] playerJoinText;
    bool[] selected;
    public float playerXOffset = 40;
    public string gameScene;
    AudioSource audioSource;
    public AudioClip navigateSound;
    public AudioClip selectSound;
    public AudioClip invalidChoiceSound;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        cm = FindObjectOfType<ControllerManager>();
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
		for(int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].gameObject.activeInHierarchy)
                selectorInstances[i].gameObject.SetActive(true);
            else
            {
                selectorInstances[i].transform.position = selectorNodes[selectorInstances[i].hoveredIndex*4 + i].position;
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
                            playerJoinText[i].text = "P" + (i + 1).ToString();
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

                    if (cm.players[i].ind.LeftStick.Left.WasPressed)
                    {
                        selectorInstances[i].hoveredIndex = selectorInstances[i].hoveredIndex - 1 < 0 ? 3 : selectorInstances[i].hoveredIndex - 1;
                        audioSource.clip = navigateSound;
                        audioSource.Play();
                    }

                    if (cm.players[i].ind.LeftStick.Right.WasPressed)
                    {
                        selectorInstances[i].hoveredIndex = selectorInstances[i].hoveredIndex + 1 > 3 ? 0 : selectorInstances[i].hoveredIndex + 1;
                        audioSource.clip = navigateSound;
                        audioSource.Play();
                    }
                }
            }
        }
        bool allSelected = cm.players.Count > 0;
        for(int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].hasSelected)
            {
                allSelected = false;
                break;
            }
        }
        if (allSelected)
        {
            FindObjectOfType<ControllerManager>().AcquirePlayers = false;
            SceneNames.LoadScene(gameScene);
        }
	}


}
