using UnityEngine;
using System.Collections;


public class WaveSim : MonoBehaviour
{
    public Material mag, vel, startClear, perturb;
    public RenderTexture[] velBuffer, magBuffer;
    public Texture2D waveThing, otherWaveThing;
    public float decayFactor = 0.99f;
    public float timeScale = 1;
    int flipIndex = 0;
    // Use this for initialization
    void Start()
    {
        Texture2D tex = new Texture2D(256,256);
        tex.SetPixel(0, 0, Color.gray);
        tex.Apply();
        for(int i = 0; i < 2; i++)
        {
            Graphics.SetRenderTarget(velBuffer[i]);
            Graphics.Blit(tex, startClear);
            Graphics.SetRenderTarget(magBuffer[i]);
            Graphics.Blit(tex, startClear);

        }
        Graphics.Blit(waveThing, magBuffer[0]);
        StartCoroutine(perturbation());

    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("deltaTime", Time.deltaTime);
        Shader.SetGlobalFloat("timeScale", timeScale);
        Shader.SetGlobalFloat("decayFactor", decayFactor);

        vel.SetTexture("_PrevVelTex", velBuffer[1]);
        Graphics.SetRenderTarget(velBuffer[0]);
        Graphics.Blit(magBuffer[0], vel);

        mag.SetTexture("_PrevMagTex", magBuffer[0]);
        Graphics.SetRenderTarget(magBuffer[1]);
        Graphics.Blit(velBuffer[0], mag);

        vel.SetTexture("_PrevVelTex", velBuffer[0]);
        Graphics.SetRenderTarget(velBuffer[1]);
        Graphics.Blit(magBuffer[1], vel);

        mag.SetTexture("_PrevMagTex", magBuffer[1]);
        Graphics.SetRenderTarget(magBuffer[0]);
        Graphics.Blit(velBuffer[1], mag);

    }

    IEnumerator perturbation()
    {
        yield return new WaitForSeconds(0.4f);
        Graphics.SetRenderTarget(magBuffer[0]);
        float x = Random.value;
        float y = Random.value;
        //perturb.SetVector("_Position", new Vector4(x-0.5f, 0.25f * y + 0.6f, 0, 0));
        perturb.SetVector("_Position", new Vector4(x, 0.25f * y + 0.6f, 0, 0));
        for (int i = 0; i < 10; i++)
        {
            yield return null;
            Graphics.Blit(waveThing, perturb);
        }
        StartCoroutine(perturbation());
    }
}