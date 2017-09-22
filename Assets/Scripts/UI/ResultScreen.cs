using System.Collections;
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

        float seconds = time - (Mathf.Floor(time / 60) * 60);
        float minutes = Mathf.Floor(time / 60);
        string secondString = "";
        string minuteString = "";
        float milliseconds = (Mathf.Round(seconds * 100));
        if (seconds < 10)
        {

            if(milliseconds % 10 == 0)
            {
                secondString = "0" + (milliseconds/100).ToString() + "0";
            }
            else
            {
                secondString = "0" + (milliseconds / 100).ToString();
            }
        }
        else
        {
            if (milliseconds % 10 == 0)
            {
                secondString = (milliseconds / 100).ToString() + "0";
            }
            else
            {
                secondString = (milliseconds / 100).ToString();
            }
        }
             
        

        if (minutes < 10)
        {
            minuteString = "0" + minutes.ToString();
        }

        scoreObjectInstance.nameText.text = data.name;
        scoreObjectInstance.timeText.text = minuteString + ":" + secondString;
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
}
