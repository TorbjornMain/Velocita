using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InControlSingleton : MonoBehaviour {
    private static InControlSingleton refer;

	// Use this for initialization
	void Start () {
        if (refer != null)
            DestroyImmediate(gameObject);
        else
            refer = this;
	}
}
