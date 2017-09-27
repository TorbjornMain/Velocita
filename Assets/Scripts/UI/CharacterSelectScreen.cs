using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScreen : MonoBehaviour {
    ControllerManager cm;

    public SelectorObject selectorPrefab;

    List<SelectorObject> selectorInstances = new List<SelectorObject>();

    public List<Transform> selectorNodes;
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
        selected = new bool[selectorNodes.Count];
        for(int i = 0; i < cm.players.Count; i++)
        {
            SelectorObject si = Instantiate<SelectorObject>(selectorPrefab);
            si.playerIndex = i;
            si.transform.SetParent(transform);
            selectorInstances.Add(si);
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].hasSelected)
            {
                if (cm.players[i].ind.Action1.WasPressed)
                {
                    if (!selected[selectorInstances[i].hoveredIndex])
                    {
                        selected[selectorInstances[i].hoveredIndex] = true;
                        PControlData playerData = cm.players[i];
                        playerData.col = ((RacerColor)selectorInstances[i].hoveredIndex);
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

                if(cm.players[i].ind.LeftStick.Left.WasPressed)
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
        for(int i = 0; i < selectorNodes.Count; i++)
        {
            int playersHovered = 0;
            for(int j = 0; j < cm.players.Count; j++)
            {
                if(selectorInstances[j].hoveredIndex == i)
                {
                    selectorInstances[j].transform.position = selectorNodes[i].position + new Vector3(1, 0, 0) * playerXOffset*playersHovered;
                    playersHovered++;
                }
            }
        }
        bool allSelected = true;
        for(int i = 0; i < cm.players.Count; i++)
        {
            if (!selectorInstances[i].hasSelected)
            {
                allSelected = false;
                break;
            }
        }
        if (allSelected)
            SceneNames.LoadScene(gameScene);

	}


}
