using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMissile : PowerupEntity {

    Vector3 startPos;
    Vector3 prevPos = Vector3.zero;
    Transform targ;


    public AnimationCurve arc;
    public float maxHeight;
    public float airTime;
    public float aimOffset = 20;
    public float collisionTime = 0.1f;

    public GameObject explosion;

    float curTime = 0;


    Rigidbody rb;
    Collider c;


	// Use this for initialization
	void Start () {
        c = GetComponent<Collider>();
        c.enabled = false;
        StartCoroutine(ActivateCollider());
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        List<LapGateUser> lg = FindObjectOfType<PlayerSpawner>().playerLaps;
        int index = lg.IndexOf(p.GetComponent<LapGateUser>()) - 1;
        if (index < 0)
        {
            targ = new GameObject().transform;
            targ.transform.position = transform.position;
            targ.transform.forward = p.transform.forward;
            Destroy(targ.gameObject, airTime + 1);
        }
        else
        {
            targ = lg[index].transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        rb.MovePosition(arcInterp(startPos, targ.transform.position+targ.transform.forward * aimOffset, curTime/airTime));
        transform.forward = (rb.transform.position - prevPos).normalized;
        if(curTime/airTime > 1)
        {
            Explode();
        }
        prevPos = rb.transform.position;
	}

    Vector3 arcInterp(Vector3 a, Vector3 b, float t)
    {
        Vector3 output = Vector3.Lerp(a, b, t);
        output.y += maxHeight * arc.Evaluate(t);
        return output;
    }

    void Explode()
    {
        Instantiate(explosion).transform.position = transform.position;
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        Instantiate(explosion).transform.position = transform.position;
        Destroy(gameObject);
    }


    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(collisionTime);
        c.enabled = true;
    }
}
