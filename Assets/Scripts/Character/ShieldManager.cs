using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {
    public bool shielded
    {
        get
        { return _shielded; }
        set
        { if (value) _shielded = true; else StartCoroutine(reset(0.05f)); }

    }

    bool _shielded = false;
    public Renderer sphereRenderer;
    public AudioSource shieldOffSound;
    
    void Update()
    {
        sphereRenderer.enabled = shielded;
    }

    public IEnumerator reset(float time)
    {
        yield return new WaitForSeconds(time);
        AudioSource a = Instantiate(shieldOffSound);
        a.transform.position = Vector3.zero;
        Destroy(a.gameObject,5);
        _shielded = false;
    }
}
