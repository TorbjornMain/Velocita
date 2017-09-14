using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAssignTextManager : MonoBehaviour {
    ControllerManager cm;

    public Text[] playerText;

    private void Start()
    {
        cm = FindObjectOfType<ControllerManager>();
    }
    // Update is called once per frame
 	void Update () {
		for(int i = 0; i < playerText.Length; i++)
        {
            if(i < cm.players.Count)
            {
                playerText[i].text = "Player " + (i + 1).ToString();
            }
            else
            {
                playerText[i].text = "Press A to Join";
            }
        }
	}


}
