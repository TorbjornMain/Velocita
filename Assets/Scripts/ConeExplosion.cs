using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeExplosion : MonoBehaviour {

    [Range(0, 1)]
    public float slowFactor = 0.5f;
    public float radius = 30;
    public float angle = 20;
    public float expTime = 0.5f;
    float time = 0;
    public LayerMask hitTargets;

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
                if (Mathf.Acos(Vector3.Dot((item.transform.position - transform.position).normalized, -transform.forward)) < angle)
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
                cr.velocity = cr.velocity * slowFactor;
            }
        }
        else
        {
            Rigidbody cr = col.GetComponent<Rigidbody>();
            cr.velocity = cr.velocity * slowFactor;
        }
        col.SendMessage("Explode", SendMessageOptions.DontRequireReceiver);
    }
}
