using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBomblet : MonoBehaviour {

    public Explosion e;
    public float force = 10;


	// Use this for initialization
	void Start() {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
	}
	
	void OnCollisionEnter(Collision c)
    {
        Instantiate(e).transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
