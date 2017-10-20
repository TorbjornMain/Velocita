using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : PowerupEntity {
    public Explosion exp;
    public float collisionTime = 0.2f;
    public float dissapearTime = 30;
    public float mineFloatHeight;
    Collider c;
	// Use this for initialization
	void Start () {
        c = GetComponent<Collider>();
        c.isTrigger = true;
        c.enabled = false;
        RaycastHit rc = new RaycastHit();
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out rc, 1000, 1 << LayerMask.NameToLayer("Terrain")))
        {
            transform.position = rc.point + new Vector3(0, mineFloatHeight, 0);
        }
        StartCoroutine(ActivateCollider());
        Destroy(gameObject, dissapearTime);
	}

    void OnTriggerEnter(Collider other)
    {
        Rigidbody crb = other.GetComponent<Rigidbody>();
        ShieldManager cs = other.GetComponent<ShieldManager>();
        if (cs != null)
        {
            if (!cs.shielded)
            {
                if (crb != null)
                {
                    crb.velocity = Vector3.zero;
                }
            }
            else
            {
                cs.shielded = false;
            }
        }
        else
        {
            if (crb != null)
            {
                crb.velocity = Vector3.zero;
            }
            other.SendMessage("Explode",SendMessageOptions.DontRequireReceiver);
        }
        Instantiate(exp).transform.position = transform.position - transform.up * 4;
        Destroy(gameObject);
    }

    void Explode()
    {
        Instantiate(exp).transform.position = transform.position - transform.up * 4;
        Destroy(gameObject);
    }
    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(collisionTime);
        c.enabled = true;
    }
}
