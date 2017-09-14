using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {

    public Vector2 startList;
    public float yOffset;
    public float spawnOffset;
    public float timeDelay = 1;
    public float listItemDelay = 0.7f;
    public string menuScene;
    public Font f;

    Text resultEntryGen(int position, LapGateUserData data)
    {
        Text t = new GameObject().AddComponent<Text>();
        t.alignment = TextAnchor.MiddleCenter;
        t.font = f;
        t.color = Color.black;
        t.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
        t.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30);
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

        t.text = (position + 1).ToString() + ": " + data.name + " Time: " + minuteString + ":" + secondString;
        t.rectTransform.SetParent(transform);
        t.transform.localPosition = new Vector3(startList.x - spawnOffset, startList.y - yOffset * position, 0);
        iTween.MoveTo(t.gameObject, iTween.Hash( "position", transform.TransformPoint(new Vector3(startList.x, startList.y - yOffset * position, 0)), "time", timeDelay, "easeType", iTween.EaseType.easeOutElastic));
        return t;
       
    }

    IEnumerator delaySpawn(int position, LapGateUserData data)
    {
        yield return new WaitForSeconds(position * listItemDelay);
        resultEntryGen(position,data);
    }

	// Use this for initialization
	void Start () {
        PlayerStandings ps = FindObjectOfType<PlayerStandings>();
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(menuScene);
        }
    }
}
