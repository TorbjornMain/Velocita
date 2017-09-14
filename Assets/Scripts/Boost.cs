using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : PowerupEntity {
    [Range(0, 2)]
    public float boostFactor;
	// Use this for initialization
	protected virtual void Start () {
        p.StartCoroutine(p.Boost(0, boostFactor));
        Destroy(gameObject);
	}
}
