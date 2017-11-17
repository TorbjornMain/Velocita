﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {

    public Vector2 startList;
    public ResultCard scoreObjectPrefab;
    public float yOffset;
    public float spawnOffset;
    public float timeDelay = 1;
    public float listItemDelay = 0.7f;
    public string menuScene;
    public Color AICardColour = Color.white;
    public Color RedCardColour = Color.red;
    public Color BlueCardColour = Color.blue;
    public Color YellowCardColor = Color.yellow;
    public Color GreenCardColor = Color.magenta;

    void resultEntryGen(int position, LapGateUserData data)
    {
        ResultCard scoreObjectInstance = Instantiate(scoreObjectPrefab);
        Color col = (data.racerCol == RacerColor.White) ? AICardColour : ((data.racerCol == RacerColor.Red) ? RedCardColour : ((data.racerCol == RacerColor.Blue) ? BlueCardColour: ((data.racerCol == RacerColor.Green) ? GreenCardColor : (YellowCardColor))));
        scoreObjectInstance.GetComponent<Image>().color = col;
        float time = 0;
        for(int i = 0; i < data.lapTimes.Count; i++)
        {
            time += data.lapTimes[i];
        }

        scoreObjectInstance.nameText.text = data.name;
        scoreObjectInstance.timeText.text = ToMinuteSeconds(time);
        scoreObjectInstance.transform.SetParent(transform);
        scoreObjectInstance.transform.localPosition = new Vector3(startList.x - spawnOffset, startList.y - yOffset * position, 0);
        iTween.MoveTo(scoreObjectInstance.gameObject, iTween.Hash( "position", transform.TransformPoint(new Vector3(startList.x, startList.y - yOffset * position, 0)), "time", timeDelay, "easeType", iTween.EaseType.easeOutExpo));
       
    }

    IEnumerator delaySpawn(int position, LapGateUserData data)
    {
        yield return new WaitForSeconds(position * listItemDelay);
        resultEntryGen(position,data);
    }

	// Use this for initialization
	void OnEnable () {
        PlayerStandings ps = FindObjectOfType<PlayerStandings>();
        ps.standings.Sort();
	    for(int i = 0; i < ps.standings.Count; i++)
        {
            StartCoroutine(delaySpawn(i, ps.standings[i]));
        }
        Destroy(ps.gameObject);
	}

    private void Update()
    {
        if(InControl.InputManager.ActiveDevice.Action1.WasPressed)
        {
            SceneNames.LoadScene(SceneNames.MainMenu);
        }
    }

    string ToMinuteSeconds(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = time - minutes * 60;
        return minutes.ToString() + ":" + seconds.ToString("00.00");
    }
}
