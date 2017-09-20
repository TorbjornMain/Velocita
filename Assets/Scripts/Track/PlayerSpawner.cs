using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerSpawner : MonoBehaviour {
    [System.NonSerialized]
    public List<PlayerController> players = new List<PlayerController>();
    [System.NonSerialized]
    public List<LapGateUser> playerLaps = new List<LapGateUser>();
    public Vector3[] spawnLocations;
    public PlayerController playerPrefab;
    public AIController aiPrefab;
    public HUDController HUDPrefab;
    List<HUDController> playerHUDs = new List<HUDController>();
    public int laps;
    public bool AI;
    PlayerStandings ps;
    public string endRaceScene;
    public bool rollingStart = false;
    [Range(0,1)]
    public float rubberbanding;
    float baseTopSpeed;
    public void SpawnPlayers(List<PControlData> devices)
    {
        RollingStartGate rs = null;
        if (rollingStart)
            rs = FindObjectOfType<RollingStartGate>();
        for(int i = 0; i < devices.Count; i++)
        {
            if(i < spawnLocations.Length)
            {
                players.Add(Instantiate<PlayerController>(playerPrefab));
                players[players.Count - 1].id = devices[i].ind;
                players[players.Count - 1].transform.position = transform.TransformPoint(spawnLocations[i]);
                players[players.Count - 1].transform.rotation = this.transform.rotation;
                players[players.Count - 1].colour = devices[i].col;
               
                HUDController h = Instantiate<HUDController>(HUDPrefab);
                h.numLaps = laps;
                h.player = players[players.Count - 1].GetComponent<HoverboardController>();
                h.player.rollingStart = rollingStart;
                h.GetComponent<Canvas>().worldCamera = players[i].hudCam;
                h.ps = this;
                playerHUDs.Add(h);
                playerLaps.Add(h.playerLapGateUser = players[players.Count - 1].GetComponent<LapGateUser>());
                playerLaps[playerLaps.Count - 1].data.name = devices[i].col.ToString();
                playerLaps[playerLaps.Count - 1].data.racerCol = devices[i].col;
                if (rollingStart)
                {
                    iTween.MoveTo(players[players.Count - 1].gameObject, iTween.Hash("speed", 100, "position", rs.transform.TransformPoint(rs.playerStartPositions[i]), "easetype", iTween.EaseType.linear, "oncomplete", "FinishRollingStart", "onupdatetarget", players[players.Count - 1].gameObject, "oncompleteparams", h));
                    players[players.Count - 1].GetComponent<Rigidbody>().velocity = transform.forward * 100;

                }
            }
        }
        if (AI)
        {
            for (int i = devices.Count; i < spawnLocations.Length; i++)
            {
                LapGateUser lgu = Instantiate<AIController>(aiPrefab).GetComponent<LapGateUser>();
                lgu.name = lgu.data.name = "AI " + i.ToString();
                lgu.data.racerCol = RacerColor.White;
                lgu.transform.position = transform.TransformPoint(spawnLocations[i]);
                lgu.transform.rotation = transform.rotation;
                playerLaps.Add(lgu);
            }
        }
        switch (players.Count)
        {
            case 1:
                players[0].cam.rect = new Rect(0, 0, 1, 1);
                players[0].hudCam.rect = new Rect(0, 0, 1, 1);
                break;
            case 2:
                players[1].cam.rect = new Rect(0, 0, 1, 0.5f);
                players[0].cam.rect = new Rect(0, 0.5f, 1, 0.5f);
                players[1].hudCam.rect = new Rect(0, 0, 1, 0.5f);
                players[0].hudCam.rect = new Rect(0, 0.5f, 1, 0.5f);
                break;
            case 3:
                players[0].cam.rect = new Rect(0, 0.5f, 1, 0.5f);
                players[1].cam.rect = new Rect(0, 0, 0.5f, 0.5f);
                players[2].cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                players[0].hudCam.rect = new Rect(0, 0.5f, 1, 0.5f);
                players[1].hudCam.rect = new Rect(0, 0, 0.5f, 0.5f);
                players[2].hudCam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                break;
            case 4:
                players[2].cam.rect = new Rect(0, 0, 0.5f, 0.5f);
                players[3].cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                players[0].cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                players[1].cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                players[2].hudCam.rect = new Rect(0, 0, 0.5f, 0.5f);
                players[3].hudCam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                players[0].hudCam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                players[1].hudCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                break;
            default:
                break;
        }
        ps = new GameObject().AddComponent<PlayerStandings>();
        DontDestroyOnLoad(ps);
        baseTopSpeed = playerPrefab.GetComponent<HoverboardController>().topSpeed;
    }

    private void Update()
    {
        for(int i = 0; i < playerLaps.Count; i++)
        {
            if(playerLaps[i].lap > laps)
            {
                bool found = false;
                for(int j = 0; j < ps.standings.Count; j++)
                {
                    if (ps.standings[j].name == playerLaps[i].data.name)
                        found = true;
                }
                if (!found)
                {
                    ps.standings.Add(playerLaps[i].data);
                    playerLaps[i].gameObject.SendMessage("FinishRace");
                    playerHUDs[players.IndexOf(playerLaps[i].GetComponent<PlayerController>())].SendMessage("FinishRace");
                }
            }
        }
        int fin = 0;
        for(int i = 0; i < players.Count; i++)
        {
            if (players[i].finished)
                fin++;
        }
        if (fin == players.Count)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(endRaceScene);
        }
        playerLaps.Sort();
        //lg.Sort();
        for (int i = 0; i < playerLaps.Count; i++)
        {
            HoverboardController hc = playerLaps[i].GetComponent<HoverboardController>();
            hc.topSpeed = Mathf.Lerp(hc.topSpeed, baseTopSpeed + (baseTopSpeed * rubberbanding * ((float)i /(float)playerLaps.Count)), 0.1f);

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for(int i = 0; i < spawnLocations.Length; i++)
        {
            Gizmos.DrawSphere(transform.TransformPoint(spawnLocations[i]), 0.8f);
        }
    }
}
