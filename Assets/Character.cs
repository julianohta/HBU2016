using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public BoxCollider2D myCollider;
	public Rigidbody2D myBody;
	public Transform myTransform;
	public SpriteRenderer myRenderer;
	public Sprite[] mySprites;
	public float movementRate;

	int health;
	bool grounded, facingRight;
	private CharacterAnimator myAnimator;

	// Use this for initialization
	void Start () {
		facingRight = true;
		health = 100;
		myBody.drag = .5f;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag.Equals ("enemyProjectile")) {
			other.gameObject.SendMessage ("hit");
			myAnimator = new CharacterAnimator (new int[]{0,1,0,1,0,1}, this, movementRate);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("hi");
		if (!grounded) {
			checkGrounded ();
		}
		myAnimator.Animate (myBody.velocity);
	}

	public void jump () {
		if (grounded) {
			grounded = false;
			myBody.velocity.Set(myBody.velocity.x, 5f);
		}
	}

	void checkGrounded () {
		RaycastHit2D hit = Physics2D.Raycast (myTransform.position, Vector2.down);
		if (hit.collider != null && hit.distance < 2.0f && myBody.velocity.y <= 0) {
			grounded = true;
		}
	}

	public void SetFrame (int frame) {
		myRenderer.sprite = mySprites [frame];
	}

	public void Move(Vector2 force) {
		if (force.x > 0 && !facingRight) {
			Flip ();
		}
		else if (force.x < 0 && facingRight) {
			Flip ();
		}
		myBody.AddForce (force);
	}

	void Flip () {
		if (facingRight) {
			facingRight = false;
			transform.localScale = new Vector2 (-1, 1);
		}
		else {
			facingRight = true;
			transform.localScale = new Vector2 (1, 1);
		}
	}

	public void Attack(float range) {
		//create projectile
	}
}
