﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundDetach : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.SetParent(null);
        Destroy(gameObject, 5);
	}

}
