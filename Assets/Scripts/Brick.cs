using UnityEngine;
using System.Collections;


public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableBricks = 0;
	public AudioClip crack;
	public GameObject debrisfx;


	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableBricks++;
		
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableBricks--;
			levelManager.BrickDestroyed ();
			Debris ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void Debris()
	{
		Instantiate (debrisfx, gameObject.transform.position, Quaternion.identity);
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel ();
	}
}
