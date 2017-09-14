using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostShield : PowerupEntity {

    public Explosion shieldPulse;
    public float shieldDelay = 1;
    public float duration = 30;
    float time = 0;
    ShieldManager sm;
	// Use this for initialization
	void Start () {
        sm = p.GetComponent<ShieldManager>();
        Explosion e = Instantiate(shieldPulse);
        e.transform.position = p.transform.position;
        e.transform.SetParent(p.transform);
        sm.shielded = true;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time < shieldDelay)
        {
            sm.shielded = true;
        }
        else
        {
            sm.StartCoroutine(sm.reset(duration));
            Destroy(gameObject);
        }
	}


}
