using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerupEntity {

    public float duration = 20;

    // Use this for initialization
    void Start()
    {
        ShieldManager s = p.GetComponent<ShieldManager>();
        s.shielded = true;
        s.StartCoroutine(s.reset(duration));
        Destroy(this);
    }
}
