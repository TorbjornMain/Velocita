using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct RacerOffset
{
    public RacerColor rc;
    public float dist, leftRight;
}

[RequireComponent(typeof(Rigidbody))]
public class CameraController : MonoBehaviour {
    public Camera cam;
    Rigidbody rb;
    public Vector3 camOffset;
    public Vector3 lookAtOffset;
    Quaternion rotationDelta;
    [Range(0, 100)]
    public float turnSpeed = 0.5f;
    [Range(0, 1)]
    public float directionWeight = 0.5f;

    public LayerMask hitTargets;

    public float warningDistance = 50;

    [System.NonSerialized]
    public GameObject lookAt;

    public RacerOffset[] racerOffsets;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cam.transform.parent = null;
        racerOffsets = new RacerOffset[4];
        for(int i = 0; i < racerOffsets.Length; i++)
        {
            racerOffsets[i].rc = (RacerColor)i;
        }
        lookAt = Instantiate(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 avgDir = rb.velocity.magnitude > 0.5f ? ((rb.velocity.normalized * (1-directionWeight) + transform.forward * directionWeight) / 2).normalized : transform.forward;
        rotationDelta = Quaternion.Slerp(rotationDelta, Quaternion.FromToRotation(new Vector3(0, 0, 1), avgDir), turnSpeed * Time.deltaTime);
        rotationDelta = Quaternion.Euler(rotationDelta.eulerAngles.x, rotationDelta.eulerAngles.y, 0);
        cam.transform.position = transform.position + (rotationDelta * camOffset);
        cam.transform.rotation = rotationDelta;
        lookAt.transform.position = transform.position + (rotationDelta *  lookAtOffset);

        for (int i = 0; i < racerOffsets.Length; i++)
        {
            racerOffsets[i].dist = 0;
        }
        Collider[] objs = Physics.OverlapSphere(transform.position, warningDistance, hitTargets);
        foreach (Collider item in objs)
        {
            float dot = Vector3.Dot((item.transform.position - transform.position).normalized, rotationDelta * new Vector3(0,0,-1));
            if (dot > 0)
            {
                onHit(item, (Quaternion.Inverse(rotationDelta) * Vector3.Project(item.transform.position - transform.position, rotationDelta * new Vector3(1, 0, 0))).x);
            }
        }
    }

    void onHit(Collider col, float leftRight)
    {
        PlayerController bvc = col.GetComponent<PlayerController>();
        if(bvc != null)
        {
            racerOffsets[(int)(bvc.colour)].leftRight = leftRight/warningDistance;
            racerOffsets[(int)(bvc.colour)].dist = (transform.position - col.transform.position).magnitude/warningDistance;
        }    
    }
}
