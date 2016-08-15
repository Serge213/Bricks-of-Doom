using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
		Brick.breakableBricks = 0;
    }

    public void QuitRequest() {
		Input.GetKeyDown(KeyCode.Escape);
        Application.Quit();
    }

	public void LoadNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		Brick.breakableBricks = 0;

	}

	public void BrickDestroyed() {
		if (Brick.breakableBricks <= 0) {
			LoadNextLevel();
		}
	}
}
