using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButtonDestroyer : MonoBehaviour {

    public float secondsToPersist = 1;

    

	// Use this for initialization
	void OnEnable () {
        Destroy(gameObject, secondsToPersist);
	}

    
}
