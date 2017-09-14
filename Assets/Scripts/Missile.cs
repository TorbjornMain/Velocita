using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : PowerupEntity {
    public float speed = 200;
    public float height = 5;
    public float offset = 3;

    public float trackingRadius = 50;
    public float trackingFOV = 15;
    public float trackingStrength = 1;

    Rigidbody r;
    Collider c;

    public Explosion explosion;
    public float collisionTime = 0.05f;

    // Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
        r.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * speed, ForceMode.VelocityChange);
        c = GetComponent<Collider>();
        c.enabled = false;
        StartCoroutine(ActivateCollider());
	}

    void Update()
    {
        RaycastHit rc = new RaycastHit();
        Physics.Raycast(transform.position, -transform.up, out rc);
        r.MovePosition(rc.point + rc.normal * height);
        Vector3 pRight = transform.right;
        transform.up = rc.normal;
        transform.forward = Vector3.Cross(pRight, transform.up);
        r.velocity = transform.forward * speed;


        Collider[] objs = Physics.OverlapSphere(transform.position, trackingRadius, 1 << LayerMask.NameToLayer("Player"));
        if (objs.Length > 0)
        {
            Collider item = null;
            float dist = float.PositiveInfinity;
            Collider pcol = p.GetComponent<Collider>();
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] != pcol)
                {
                    if (Mathf.Acos(Vector3.Dot((objs[i].transform.position - transform.position).normalized, transform.forward)) < trackingFOV)
                    {
                        float cDist = (objs[i].transform.position - transform.position).magnitude;
                        if (dist < cDist)
                        {
                            item = objs[i];
                            dist = cDist;
                        }
                    }
                }
            }
            if(item != null)
                onHit(item);
        }

    }
	
    void onHit(Collider item)
    {
        Vector3 dir = (item.transform.position - transform.position).normalized;
        transform.forward = Vector3.Slerp(transform.forward, dir, trackingStrength * Time.deltaTime);
    }

    void Explode()
    {
        Instantiate(explosion).transform.position = transform.position + transform.forward * offset;
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion).transform.position = transform.position + transform.forward * offset;
        Destroy(gameObject);
    }

    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(collisionTime);
        c.enabled = true;
    }

}
