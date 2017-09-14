using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudFlasher : MonoBehaviour {

    public float secondsPerFlash = 0.5f;

	// Use this for initialization
	void OnEnable () {
        StartCoroutine(Flash());
	}
	
	IEnumerator Flash()
    {
        yield return new WaitForSeconds(secondsPerFlash);
        GetComponent<Image>().color = GetComponent<Image>().color.a == 0 ? Color.white : new Color(0, 0, 0, 0);
        StartCoroutine(Flash());
    }
}
