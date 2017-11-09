using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWavePerturbation : MonoBehaviour {
    public Material perturb;
    public RenderTexture rt;

    void OnCollisionEnter(Collision other)
    {
        RaycastHit rc = new RaycastHit();
        if (Physics.Raycast(other.contacts[0].point - other.contacts[0].normal / 100, other.contacts[0].normal, out rc, 0.1f))
        {
            perturb.SetVector("_Position", new Vector4(rc.textureCoord.x, rc.textureCoord.y, 0, 0));
            Graphics.SetRenderTarget(rt);
            RenderTexture t = RenderTexture.GetTemporary(1, 1);
            Graphics.Blit(t, perturb);
            t.Release();
        }
    }
}
