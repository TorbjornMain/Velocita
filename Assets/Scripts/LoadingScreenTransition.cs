using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneNames.loading)
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneNames.sceneToLoad);
        SceneNames.loading = false;
        SceneNames.sceneToLoad = "";
    }
}
