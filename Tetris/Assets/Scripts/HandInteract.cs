using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandInteract : MonoBehaviour {
	float homeX, homeY, homeZ;
	bool alreadyGrippedL;
	bool alreadyGrippedR;
	bool alreadyClapped;
	public GameObject cube;

	Controller controller;

	void Start()
	{
		controller = new Controller ();
		alreadyGrippedL = false;
		alreadyGrippedR = false;
		alreadyClapped = false;
	}

	void Update()
	{

		if (Time.frameCount % 25 == 0) {

			Frame frame = controller.Frame ();

			float strengthL = 0f;
			float strengthR = 0f;
			if (frame.Hands.Count > 1) {
				Hand handL = frame.Hands [1];
				Hand handR = frame.Hands [0];

				//Vector palmL = handL.PalmPosition;
				//Vector palmR = handR.PalmPosition;
				//List<Finger> finger = hand.Fingers;
				strengthL = handL.GrabStrength;
				strengthR = handR.GrabStrength;

				//float handSpeedL = handL.PalmVelocity;
				//float handSpeedR = handR.PalmVelocity;

				//Tetris.C.log ("LEFT " + strengthL + "\tRIGHT " + strengthR);

				if (strengthL >= 0.9 && !alreadyGrippedL) { // hand is gripped
					//homeX = hand.Basis.xBasis.x;
					//homeY = hand.Basis.yBasis.y;
					Debug.Log ("left");
					//Tetris.C.move (-1);
					alreadyGrippedL = true; // set true for first time
					//Instantiate(cube, 
				}
				if (strengthR >= 0.9 && !alreadyGrippedR) { // hand is gripped
					//homeX = hand.Basis.xBasis.x;
					//homeY = hand.Basis.yBasis.y;
					Debug.Log ("right");
					//Tetris.C.move (1);
					alreadyGrippedR = true; // set true for first time
					//Instantiate(cube, 
				}

				if (strengthR < 0.9) { // if the hand is release when previously gripped
					alreadyGrippedR = false; // is not gripped
				}
				if (strengthL < 0.9) { // if the hand is release when previously gripped
					alreadyGrippedL = false; // is not gripped
				}

				if (alreadyGrippedL && alreadyGrippedR) {
					Tetris.C.clap ();
				} else if (alreadyGrippedL) {
					Tetris.C.move (-1);
				} else if (alreadyGrippedR) {
					Tetris.C.move (1);
				}

				/*
			if (Mathf.Abs (handR.Basis.xBasis.x - handL.Basis.xBasis.x) < 0.1 && !alreadyClapped) {
				alreadyClapped = true;
				//Debug.Log ("clap");
				//Tetris.C.rotate ();
			} else
				alreadyClapped = false;
			*/

				//Debug.Log (hand.Basis.xBasis.x);
			}
		}
	}
}
