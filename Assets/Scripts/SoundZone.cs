using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SoundZone : MonoBehaviour {

    public AudioSource soundPrefab;
    Dictionary<GameObject, AudioSource> sounds;
    SphereCollider c;

	// Use this for initialization
	void Start () {
        sounds = new Dictionary<GameObject, AudioSource>();
        c = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var sound in sounds)
        {
            sound.Value.gameObject.transform.position = transform.position - sound.Key.transform.position;
            sound.Value.volume = (transform.position - sound.Key.transform.position).magnitude / sound.Value.maxDistance;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        sounds.Add(other.gameObject, Instantiate(soundPrefab));
        sounds[other.gameObject].maxDistance = c.radius;
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(sounds[other.gameObject].gameObject);
        sounds.Remove(other.gameObject);
    }
}
