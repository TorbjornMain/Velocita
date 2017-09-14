using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapGateManager : MonoBehaviour {
    public List<LapGate> gates;

	// Use this for initialization
	void Awake () {
        gates = new List<LapGate>(FindObjectsOfType<LapGate>());
        gates.Sort();
        
	}
	
}
