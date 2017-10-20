using System.Collections;
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
    public List<PControlData> players = new List<PControlData>();
    private static ControllerManager refer;
    InGameGlobalUIManager igguim;
    

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
            } 
            //if(InputManager.ActiveDevice.Action4.WasPressed)
            //{
            //    for(int i = 0; i < players.Count; i++)
            //    {
            //        if(players[i].ind == InputManager.ActiveDevice)
            //        {
            //            players.RemoveAt(i);
            //            break;
            //        }
            //    }
            //}
        }
        else
        {
            if (InputManager.ActiveDevice.MenuWasPressed && igguim != null)
                igguim.SendMessage("TogglePause");
                
        }
	}
    void OnLevelWasLoaded()
    {
        PlayerSpawner p = FindObjectOfType<PlayerSpawner>();
        igguim = FindObjectOfType<InGameGlobalUIManager>();
        if (p != null)
        {
            p.SpawnPlayers(players);
        }
    }
}
