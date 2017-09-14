using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurster : MonoBehaviour {
    public new GameObject particleSystem;
    public float lifeTime = 0.5f;
    public Vector3 position, direction;
    private GameObject instance;


    public void Spawn(Color c)
    {
        instance = Instantiate<GameObject>(particleSystem);
        ParticleSystem.MainModule pm = instance.GetComponent<ParticleSystem>().main;
        pm.startColor = c;
        instance.transform.position = transform.TransformPoint(position);
        instance.transform.forward = transform.TransformDirection(direction);
        instance.transform.parent = transform;
        instance.transform.localScale = Vector3.one;
        Destroy(instance, lifeTime);
    }
    public void Spawn()
    {
        instance = Instantiate<GameObject>(particleSystem);
        instance.transform.position = transform.TransformPoint(position);
        instance.transform.forward = transform.TransformDirection(direction);
        instance.transform.parent = transform;
        instance.transform.localScale = Vector3.one;
        Destroy(instance, lifeTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.TransformPoint(position), Vector3.one * 0.1f);
        Gizmos.DrawLine(transform.TransformPoint(position), transform.TransformPoint(position) + transform.TransformDirection(direction));
    }
}
