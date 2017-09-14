﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public struct PControlData
{
    public InputDevice ind;
    public RacerColor col;
}
public class ControllerManager : MonoBehaviour {

    public bool AcquirePlayers = false;
    public string mainGameScene;
    public List<PControlData> players = new List<PControlData>();
    private static ControllerManager refer;

    

	// Use this for initialization
	void Start () {
        if(refer != null)
        {
            refer.AcquirePlayers = this.AcquirePlayers;
            DestroyImmediate(gameObject);
            return;
        }
        refer = this;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {

		if(AcquirePlayers)
        {
            if(InputManager.ActiveDevice.Action1.WasPressed)
            {
                bool isController = false;

                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].ind == InputManager.ActiveDevice)
                    {
                        isController = true; break;
                    }
                }

                if(!isController)
                {
                    if (players.Count < 4)
                    {
                        PControlData p = new PControlData();
                        p.ind = InputManager.ActiveDevice;
                        players.Add(p);
                    }
                }
                else
                {
                    AcquirePlayers = false;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(mainGameScene);
                }
            } 
        }
	}
    void OnLevelWasLoaded()
    {
        PlayerSpawner p = FindObjectOfType<PlayerSpawner>();
        if (p != null)
        {
            p.SpawnPlayers(players);
        }
    }
}