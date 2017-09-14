using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSoundEffect : MonoBehaviour {
    public AudioSource soundEffectPrefab;
    AudioSource soundEffectInstance;
	// Use this for initialization
	void Start () {
        soundEffectInstance = Instantiate(soundEffectPrefab);
        soundEffectInstance.transform.position = new Vector3(0, 0, 0);
	}
}
