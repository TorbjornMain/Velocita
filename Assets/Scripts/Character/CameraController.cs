using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraController : MonoBehaviour {
    public Camera cam;
    Rigidbody rb;
    public Vector3 camOffset;
    Quaternion rotationDelta;
    [Range(0, 100)]
    public float turnSpeed = 0.5f;
    [Range(0, 1)]
    public float directionWeight = 0.5f;
    LapGateUser lg;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lg = GetComponent<LapGateUser>();
        cam.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 avgDir = rb.velocity.magnitude > 0.5f ? ((rb.velocity.normalized * (1-directionWeight) + transform.forward * directionWeight) / 2).normalized : transform.forward;
        Vector3 trackAng = lg.trackAngle;
        trackAng.y = 0;
        rotationDelta = Quaternion.Slerp(rotationDelta, Quaternion.FromToRotation(new Vector3(0, 0, 1), avgDir), turnSpeed * Time.deltaTime);
        rotationDelta = Quaternion.Euler(rotationDelta.eulerAngles.x, rotationDelta.eulerAngles.y, 0);
        cam.transform.position = transform.position + ( rotationDelta * Quaternion.Euler(trackAng) * camOffset);
        cam.transform.rotation = rotationDelta * Quaternion.Euler(trackAng);
    }
}
