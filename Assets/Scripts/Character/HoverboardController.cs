﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Controller))]
public class HoverboardController : MonoBehaviour
{
    public Vector3[] baseOffsets;
    public float desiredHeight = 0.5f;
    public float maxHeight = 5;
    public float floatStrength = 10;
    public Vector3 maxControlledDeflection = new Vector3(30, 90, 15);
    public Vector3 maxAccelerationDeflection = new Vector3(5, 90, 15);
    public Vector3 maxDeflection = Vector3.one * 60;
    public float accelerationDownforce = 1;
    public float driftDownforce = 1;
    public float driftBrakeFactor = 0.3f;
    public float angularControl = 20;
    public float acceleration = 1000;
    public float driftAcceleration = 500;
    public float groundingForce = 5;
    public float driftRate = 7;
    public float turnRate = 2;
    public float accelTurnRate = 1;
    public float accelStrafeSpeed = 1;
    public float driftBoostFactor = 1;
    public float jumpDelay = 1;
    public float boostDownforce = 1;
    public float hopForce = 1;
    public AnimationCurve boostAccelFalloff;
    public float boostLength;
    public float topSpeed = 100;
    public float speedDamping = 0.5f;
    public float boostSlideCancel = 1;
    public float angleCancellation = 0.2f;
    public bool rollingStart = false;
    public float rollingStartVel = 100;
    public float speedCap = 400;
    public float speed
    {
        get
        {
            return r.velocity.magnitude;
        }
    }

    public Vector3 velocity
    {   
        get
        {
            return r.velocity;
        }
    }


    float preDriftSpeed;
    Vector3 preDriftDirection;
    bool canJump = true;
    bool boosting = false;

    Rigidbody r;
    Controller c;

    public Controller controller
    {
        get
        {
            return c;
        }
    }

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Rigidbody>();
        c = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rollingStart)
        {
            bool isGrounded = false;
            for (int i = 0; i < baseOffsets.Length; i++)
            {
                RaycastHit rc = new RaycastHit();
                if (Physics.Raycast(transform.TransformPoint(baseOffsets[i]), -transform.up, out rc, desiredHeight, 1<<LayerMask.NameToLayer("Terrain")))
                {
                    r.AddForceAtPosition(transform.up * (1 - rc.distance / (desiredHeight)) * floatStrength / baseOffsets.Length, transform.TransformPoint(baseOffsets[i]), ForceMode.Acceleration);
                    isGrounded = true;
                }
            }


            if (!isGrounded)
            {
                r.AddForce(groundingForce * new Vector3(0, -1, 0) * (r.velocity.y > 0 ? 3 : 1));
            }
            //float forwardInput = Input.GetAxis("Vertical");

            Vector3 controlInput = c.SteerInput;
            controlInput.z *= -1;
            float pitch = ((transform.eulerAngles.x + 180) % 360 - 180);
            float roll = ((transform.eulerAngles.z + 180) % 360 - 180);

            if (c.HopPressed)
            {
                Jump();
            }

            if (c.DriftPressed)
            {
                StartDrift();
            }

            if (c.DriftReleased)
            {
                EndDrift();
            }

            if (c.DriftHeld)
            {
                Drift(controlInput);
            }
            else if (c.AccelInput > 0.5f)
            {
                Accelerate(controlInput);
            }
            else
            {
                Neutral(controlInput);
            }

            r.MoveRotation(Quaternion.Euler(Mathf.Clamp(pitch, -maxDeflection.x, maxDeflection.x), transform.eulerAngles.y, Mathf.Clamp(roll, -maxDeflection.z, maxDeflection.z)));


            RaycastHit ray = new RaycastHit();
            if (!Physics.Raycast(transform.position, new Vector3(0, -1, 0), out ray, maxHeight))
            {
                if (Mathf.Sign(r.velocity.y) == 1)
                {
                    r.velocity = new Vector3(r.velocity.x, 0, r.velocity.z);
                }
            }
            else if (Mathf.Sign(r.velocity.y) == -1)
            {
                r.velocity = new Vector3(r.velocity.x, r.velocity.y * 0.9f, r.velocity.z);
            }

            if (speed > topSpeed && !boosting)
            {
                r.AddForce((1 - speedDamping) * -r.velocity, ForceMode.Acceleration);
            }
            if (velocity.magnitude > speedCap)
            {
                r.velocity = Vector3.Max(velocity.normalized * speedCap, velocity);
            }
        }
        else
        {
            r.velocity = transform.forward * rollingStartVel;
        }
    }

    void FinishRollingStart(HUDController h)
    {
        rollingStart = false;
        h.SendMessage("FinishRolling");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < baseOffsets.Length; i++)
        {
            Gizmos.DrawLine(transform.TransformPoint(baseOffsets[i]), transform.TransformPoint(baseOffsets[i]) - (transform.rotation * new Vector3(0, desiredHeight, 0)));
        }
    }



    void Drift(Vector3 controlInput)
    {
        float pitch = ((transform.eulerAngles.x + 180) % 360 - 180);
        float roll = ((transform.eulerAngles.z + 180) % 360 - 180);
        r.AddTorque(Time.deltaTime * angularControl * transform.TransformDirection(new Vector3(-4 * (1 - (Mathf.Abs(pitch) / maxControlledDeflection.x)), -driftRate * controlInput.z, controlInput.z * (1 - (Mathf.Abs(roll) / maxControlledDeflection.z)))));
        float velDot = Vector3.Dot(transform.right, r.velocity);
        Vector3 turnBrakeForce = -velDot * transform.right * driftBrakeFactor;
        turnBrakeForce.y = 0;
        r.AddForce(turnBrakeForce);
        if (c.AccelInput > 0.5f)
            r.AddForce(Time.deltaTime * (transform.forward * driftAcceleration + driftDownforce * new Vector3(0, -1, 0)), ForceMode.Acceleration);
        
    }

    void Accelerate(Vector3 controlInput)
    {
        float pitch = ((transform.eulerAngles.x + 180) % 360 - 180);
        float roll = ((transform.eulerAngles.z + 180) % 360 - 180);
        r.AddForce(Time.deltaTime * (new Vector3(transform.forward.x, 0, transform.forward.z) * acceleration + accelerationDownforce * new Vector3(0, -1, 0)), ForceMode.Acceleration);
        r.AddForce(new Vector3(transform.right.x, 0, transform.right.z).normalized * -controlInput.z * Mathf.Lerp(0, accelStrafeSpeed, r.velocity.magnitude/topSpeed), ForceMode.Acceleration);
        r.AddTorque(Time.deltaTime * angularControl * transform.TransformDirection(new Vector3(controlInput.x * (1 - (Mathf.Abs(pitch) / maxAccelerationDeflection.x)), -accelTurnRate * controlInput.z, controlInput.z * (1 - (Mathf.Abs(roll) / maxAccelerationDeflection.z)))));

    }

    void Neutral(Vector3 controlInput)
    {
        float pitch = ((transform.eulerAngles.x + 180) % 360 - 180);
        float roll = ((transform.eulerAngles.z + 180) % 360 - 180);
        r.AddTorque(Time.deltaTime * angularControl * transform.TransformDirection(new Vector3(controlInput.x * (1 - (Mathf.Abs(pitch) / maxControlledDeflection.x)), -turnRate * controlInput.z, controlInput.z * (1 - (Mathf.Abs(roll) / maxControlledDeflection.z)))));
    }

    void StartDrift()
    {
        preDriftSpeed = r.velocity.magnitude;
        preDriftDirection = transform.forward;
    }

    void EndDrift()
    {
        float speedDif = preDriftSpeed - r.velocity.magnitude;
        Vector3 f = transform.forward;
        preDriftDirection.y = f.y = 0;
        float dirFact = 1 - Vector3.Dot(f.normalized, preDriftDirection.normalized);
        if(dirFact > 0.2f)
        {
            SendMessage("BoostVisuals", boostLength);
            boosting = true;
            StartCoroutine(Boost(speedDif, dirFact));
        }
    }

    void Jump()
    {
        if (canJump)
        {
            r.AddForce(new Vector3(0, 1, 0) * hopForce, ForceMode.VelocityChange);
            canJump = false;
            StartCoroutine(JumpReset());
        }
    }

    IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(jumpDelay);
        canJump = true;
    }
    public IEnumerator Boost(float speedDifference, float dirFactor)
    {
        if(controller as PlayerController != null)
        {
            if((controller as PlayerController).active)
            {
                float boostTime = 0;
                while (boostTime < boostLength)
                {
                    r.AddForce(Time.deltaTime * (transform.forward * acceleration * boostAccelFalloff.Evaluate(boostTime / boostLength) * driftBoostFactor * dirFactor + new Vector3(0, -1, 0) * boostDownforce), ForceMode.Acceleration);
                    r.AddForce(Time.deltaTime * -Vector3.Dot(r.velocity, transform.right) * transform.right * boostSlideCancel, ForceMode.Acceleration);
                    boostTime += Time.deltaTime;
                    yield return null;
                }
            }
        }

        boosting = false;

    }

    void ResetPlayer()
    {
        r.velocity = Vector3.zero;
    }

}
