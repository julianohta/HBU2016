using UnityEngine;
using System.Collections;

public class AnimationCycle {


	private int progressThroughCycle, numElements, startIndex, endIndex;

	// Use this for initialization
	public AnimationCycle (int _startIndex, int _endIndex) {
		numElements = _endIndex - _startIndex;
		startIndex = _startIndex;
		endIndex = _endIndex;
	}

	public int Cycle () {
		progressThroughCycle ++;
		if (progressThroughCycle >= endIndex) {
			progressThroughCycle = startIndex;
		}
		return progressThroughCycle;
	}
}
