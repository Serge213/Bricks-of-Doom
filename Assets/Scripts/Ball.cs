using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private AudioSource bounceAudio;

	public AudioClip paddleBounceAudio;

		// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		bounceAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch the ball.
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (4f, 10f);
			}
		}

	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Paddle") 
		{
			bounceAudio.Play ();
		}
	}
}
