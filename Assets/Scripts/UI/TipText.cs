using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TipText : MonoBehaviour {

    Text t;
    string[] tips;
    public string tipsFileName;
    public float tipTime = 3;
    float curTipTime = 0;


	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        LoadTips();
        t.text = tips[Random.Range(0, tips.Length)];
	}
	
	// Update is called once per frame
	void Update () {
        curTipTime += Time.deltaTime;
        if(curTipTime > tipTime)
        {
            t.text = tips[Random.Range(0, tips.Length)];
            curTipTime = 0;
        }		
	}

    void LoadTips()
    {
        TextAsset txt = Resources.Load<TextAsset>(tipsFileName);
        tips = txt.text.Split('\n');
    }
}
