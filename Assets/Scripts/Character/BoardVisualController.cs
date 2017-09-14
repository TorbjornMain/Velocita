using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HoverboardController))]
public class BoardVisualController : MonoBehaviour {
    public ParticleBurster boostParticles;
    public ParticleSystem sparkParticles;
    public ParticleSystem driftParticles;
    public Animator anim;
    public Renderer mainModelRenderer;
    ParticleSystem driftInstance;
    ParticleSystem sparkInstance;
    public TrailRenderer outerTrail;
    public TrailRenderer innerTrail;
    public AnimationCurve boostTrailWidth;
    public Camera cam;
    public float minFOV = 60;
    public float baseFOV = 90;
    public float animLerpSpeed;
    float outerW;
    float innerW;
    HoverboardController hc;
    Color col;
    Vector3 animIn = Vector3.zero;
    IKController ik;

    void Start()
    {
        hc = GetComponent<HoverboardController>();
        ik = anim.GetComponent<IKController>();
        innerW = innerTrail.widthMultiplier;
        outerW = outerTrail.widthMultiplier;
        
        if (hc.controller as PlayerController != null)
        {
            switch(((PlayerController)hc.controller).colour)
            {
                case RacerColor.Red:
                    col = Color.red;
                    break;

                case RacerColor.Blue:
                    col = Color.blue;
                    break;

                case RacerColor.Green:
                    col = Color.green;
                    break;

                case RacerColor.Yellow:
                    col = Color.yellow;
                    break;

                default:
                    col = Color.black;
                    break;
            }
        }
        else
        {
            col = Color.grey * 1.5f;
        }
        mainModelRenderer.material.color = col;
        outerTrail.startColor = outerTrail.endColor = col;
    }

    void Update()
    {
        animIn = Vector3.Lerp(animIn, hc.controller.SteerInput, 10 * Time.deltaTime);
        anim.SetFloat("Pitch", animIn.x);
        anim.SetFloat("Roll", animIn.z);
        if (hc.controller.DriftPressed)
        {
            driftInstance = Instantiate(driftParticles);
            ParticleSystem.MainModule pm = driftInstance.main;
            pm.startColor = col;
            driftInstance.transform.parent = transform;
            driftInstance.transform.localPosition = Vector3.zero;

        }
        if (hc.controller.DriftReleased)
        {
            if(driftInstance)
            {
                StartCoroutine(DestroyParticlesAfterTime(driftInstance));
                driftInstance = null;
            }
        }
        if (cam)
        {
            cam.fieldOfView = Mathf.LerpUnclamped(minFOV, baseFOV, hc.speed / hc.topSpeed);
        }
        Shader.SetGlobalFloat("Speed", hc.speed/hc.topSpeed);
    }

    void OnCollisionEnter(Collision c)
    {
        if (sparkInstance == null)
        {
            sparkInstance = Instantiate<ParticleSystem>(sparkParticles);
        }
        sparkInstance.transform.position = transform.position;//c.contacts[0].point+(c.contacts[0].normal * 0.3f);
    }

    void OnCollisionStay(Collision c)
    {
        if(sparkInstance != null)
        {
            sparkInstance.transform.position = transform.position;//c.contacts[0].point + (c.contacts[0].normal * 0.3f);
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (sparkInstance != null)
            Destroy(sparkInstance.gameObject);
    }
    void BoostVisuals(float boostLength)
    {
        boostParticles.Spawn(col);
        StartCoroutine(BoostTrailMod(boostLength));
    }

    IEnumerator BoostTrailMod(float boostLength)
    {
        float boostTime = 0;

        while (boostTime < boostLength)
        {
            outerTrail.widthMultiplier = outerW * boostTrailWidth.Evaluate(boostTime / boostLength);
            innerTrail.widthMultiplier = innerW * boostTrailWidth.Evaluate(boostTime / boostLength);
            boostTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator DestroyParticlesAfterTime(ParticleSystem p)
    {
        ParticleSystem.EmissionModule em = p.emission;
        em.rateOverTime = em.rateOverDistance = 0;
        yield return new WaitForSeconds(p.main.startLifetime.constantMax);
        Destroy(p.gameObject);        
    }
}
