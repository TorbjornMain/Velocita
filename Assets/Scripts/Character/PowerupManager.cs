using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(HoverboardController))]
public class PowerupManager : MonoBehaviour {

    [System.NonSerialized]
    public Powerup currentPowerup;

    Controller c;

	// Use this for initialization
	void Start () {
        c = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {

	    if(c.HopPressed && currentPowerup != null)
        {
            currentPowerup.Use(GetComponent<HoverboardController>());
            currentPowerup = null;
        }
	}
}
