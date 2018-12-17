using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	private string sceneToLoad = "";
	public void SetSceneToLoad(string scene) {
		sceneToLoad = scene;
	}

	public void StartLoading() {
		SceneManager.LoadScene(sceneToLoad);
	}
}
