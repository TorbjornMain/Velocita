using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller {

    LapGateUser lpg;
    Rigidbody rb;
    HoverboardController hc;
    float topspeed = 0;
    public float rayRange = 30;
    public float steerWeight = 1;
    public float accelWeight = 1;
    public float accelChangeTime = 5;
    [Range(0, 1)]
    public float speedVariance = 0.5f;
    float time = 0;
    float rnd = 0;

    void Start()
    {
        lpg = GetComponent<LapGateUser>();
        rb = GetComponent<Rigidbody>();
        lpg.trackDir = FindObjectOfType<LapGateManager>().gates[0].transform.forward;
        hc = GetComponent<HoverboardController>();
        topspeed = hc.topSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active)
        {
            RaycastHit rc = new RaycastHit();
            Vector3 fwd = transform.forward;
            fwd.y = 0;
            fwd.Normalize();
            
            float leftDist = Physics.Raycast(transform.position, Quaternion.Euler(new Vector3(0, -30, 0)) * fwd, out rc, rayRange, 1 << LayerMask.NameToLayer("Wall")) ? Mathf.Abs(rc.distance / rayRange) : 1;
            float rightDist = Physics.Raycast(transform.position, Quaternion.Euler(new Vector3(0, 30, 0)) * fwd, out rc, rayRange, 1 << LayerMask.NameToLayer("Wall")) ? Mathf.Abs(rc.distance / rayRange) : 1;

            print("LeftDistance " + leftDist.ToString() + " RightDistance " + rightDist.ToString() + " " + (rightDist - leftDist).ToString());

            if (time <= 0)
            {
                rnd = Random.Range(1 - speedVariance, 1 + speedVariance);
                time = accelChangeTime;
            }
            time -= Time.deltaTime;
            hc.topSpeed = topspeed * rnd;
            _accelInput = accelWeight;//accelWeight * frontDist * Vector3.Dot(transform.forward, lpg.trackDir);

            _steerInput = new Vector3(0, 0, steerWeight * (rightDist - leftDist));

            if(Vector3.Dot(transform.forward, lpg.trackDir) < -0.8)
            {
                transform.position = lpg.lastGatePos;
                transform.forward = lpg.trackDir;
            }
        }
	}

    void OnDrawGizmos()
    {
        Vector3 fwd = transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(new Vector3(0, -30, 0)) * fwd * rayRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(new Vector3(0, 30, 0)) * fwd * rayRange);
    }
}
