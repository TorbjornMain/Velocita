using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(HoverboardController))]
public class PowerupManager : MonoBehaviour {

    [System.NonSerialized]
    public Powerup currentPowerup;

    Controller c;
    HoverboardController hc;

	// Use this for initialization
	void Start () {
        c = GetComponent<Controller>();
        hc = GetComponent<HoverboardController>();

    }
	
	// Update is called once per frame
	void Update () {

	    if(c.HopPressed && currentPowerup != null && Time.timeScale != 0)
        {
            currentPowerup.Use(hc);
            currentPowerup = null;
        }
	}
}
