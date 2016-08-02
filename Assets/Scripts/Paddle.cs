using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);

		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 12);

		paddlePos.x = mousePosInBlocks;

		this.transform.position = paddlePos;

		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 11.5f);

	}
}
