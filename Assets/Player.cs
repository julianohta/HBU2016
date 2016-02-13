using UnityEngine;
using System.Collections;

public class Player : Character {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = Vector2.zero;
		if (Input.GetKey ("w")) {
			jump();
		}
		if (Input.GetKey ("a")) {
			input += Vector2.left*5f;
		}
		if (Input.GetKey ("d")) {
			input += Vector2.right*5f;
		}
		Move (input);
	}
}
