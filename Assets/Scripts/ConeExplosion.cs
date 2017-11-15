using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeExplosion : MonoBehaviour {

    [Range(0, 1)]
    public float slowFactor = 0.5f;
    public float radius = 30;
    [Range(0, 90)]
    public float halfAngle = 20;
    public float expTime = 0.5f;
    float time = 0;
    public LayerMask hitTargets;

    public Color hitColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        float cRad = Mathf.Lerp(0, radius, time / expTime);
        if (cRad > 0.1f)
        {
            Collider[] objs = Physics.OverlapSphere(transform.position, cRad, hitTargets.value);
            foreach (Collider item in objs)
            {
                float dot = Vector3.Dot((item.transform.position - transform.position).normalized, transform.forward);
                if (Mathf.Acos(dot) < halfAngle && dot > 0)
                {
                    onHit(item);
                }
            }
        }
        if(time > expTime)
        {
            Destroy(gameObject);
        }
	}

    void onHit(Collider col)
    {
        ShieldManager s = col.GetComponent<ShieldManager>();
        if (s != null)
        {
            if (s.shielded)
            {
                s.shielded = false;
            }
            else
            {
                Rigidbody cr = col.GetComponent<Rigidbody>();
                if (cr != null)
                    cr.velocity = cr.velocity * slowFactor;
            }
        }
        else
        {
            Rigidbody cr = col.GetComponent<Rigidbody>();
            if (cr != null)
            {
                cr.velocity = cr.velocity * slowFactor;
                col.SendMessage("PowerupHit", hitColor);
            }
        }
        col.SendMessage("Explode", SendMessageOptions.DontRequireReceiver);
    }
}
