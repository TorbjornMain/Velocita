using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Explosion : MonoBehaviour {
    SphereCollider c;
    public float radius = 20;
    public float force = 100;
    public float time = 0.5f;
    public bool turnOnly;
    float totalTime = 0;
    // Use this for initialization
    void Start () {
        c = GetComponent<SphereCollider>();
        c.isTrigger = true;
        c.radius = 0;
        Destroy(gameObject, time);
	}

    void Update()
    {
        totalTime += Time.deltaTime;
        c.radius = (totalTime / time) * radius;
    }

    void OnTriggerEnter(Collider col)
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
                cr.AddExplosionForce(force, transform.position, radius);
                cr.AddTorque(0, force * 10, 0);
            }
        }
        else
        {
            Rigidbody cr = col.GetComponent<Rigidbody>();
            if(!turnOnly)
                cr.AddExplosionForce(force, transform.position, radius, 0, ForceMode.Impulse);
            cr.AddTorque(0, force, 0, ForceMode.Impulse);
        }
        col.SendMessage("Explode", SendMessageOptions.DontRequireReceiver);
    }
}
