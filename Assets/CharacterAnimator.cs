using UnityEngine;
using System.Collections;

public class CharacterAnimator {

	private Rigidbody2D myBody;
	private Character myCharacter;
	float timeToNextFrame, movementRate;
	int currentCycle = 0; //0 idle, 1 walking, 2 falling, 3 crouching
	int progressThroughCycle;



	AnimationCycle Idle, Walk, Fall;

	// Use this for initialization
	public CharacterAnimator (int[] animationCycles, Character myCharacter, float _movementRate) {
		AnimationCycle Idle = new AnimationCycle (animationCycles[0], animationCycles[1]);
		AnimationCycle Walk = new AnimationCycle (animationCycles[2], animationCycles[3]);
		AnimationCycle Fall = new AnimationCycle (animationCycles[4], animationCycles[5]);
	}
	
	// Update is called once per frame
	public void Animate (Vector2 velocity) {
		timeToNextFrame -= Time.deltaTime;

		if (Mathf.Abs (velocity.y) > 2f) 
		{
			if (currentCycle != 2) {
				currentCycle = 2;
				timeToNextFrame = 0f;
			}
			if (timeToNextFrame <= 0) {
				myCharacter.SetFrame(Fall.Cycle ());
				timeToNextFrame = movementRate/velocity.y;
			}
		}
		else if (Mathf.Abs (velocity.x) > 0) 
		{
			if (currentCycle != 1) {
				currentCycle = 1;
				timeToNextFrame = 0f;
			}
			if (timeToNextFrame <= 0) {
				myCharacter.SetFrame(Walk.Cycle ());
				timeToNextFrame = movementRate/velocity.x;
			}
		}
		else
		{
			if (currentCycle != 0) {
				currentCycle = 0;
				timeToNextFrame = 0f;
			}
			if (timeToNextFrame <= 0) {
				myCharacter.SetFrame(Idle.Cycle ());
				timeToNextFrame = movementRate/velocity.x;
			}
		}
	}









}
