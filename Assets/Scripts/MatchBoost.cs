using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBoost : Boost {

    public ConeExplosion boostCone;
    public float offset;

	// Use this for initialization
	protected override void Start () {
        ConeExplosion c = Instantiate(boostCone);
        c.transform.position = transform.position + transform.forward * offset;
        c.transform.forward = -transform.forward;
        base.Start();
    }
    
}
