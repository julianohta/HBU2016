using UnityEngine;
using System.Collections;

public class VestigialCharacter : MonoBehaviour {

	public Transform myTransform;
	public Rigidbody2D myBody;
	public BoxCollider2D myCollider;

	float health, movementSpeed;
	bool walkCycle,fallCycle,idleCycle;
	float timeToNextFrame;


	// Use this for initialization
	void Start () {
		myBody.drag = 1;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToNextFrame > 0) {
			timeToNextFrame -= Time.deltaTime;
		}
	}

	void CheckHealth () {
		if (health < 0) {
			//game over. Reset
		}
	}

	void Move (Vector2 velocity) {
		myBody.AddForce(velocity * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "enemyBullet") {
			other.gameObject.SendMessage("hit");
			health -= 10;
		}
	}
	









}
