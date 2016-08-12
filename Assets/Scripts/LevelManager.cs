﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableBricks <= 0) {
			LoadNextLevel();
		}
	}
}
