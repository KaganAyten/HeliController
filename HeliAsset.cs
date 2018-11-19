    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliAsset : MonoBehaviour {

	Rigidbody rb;
	public GameObject frontPropeller;
	public GameObject backPropeller;
	public bool TurnOn;

	AudioSource heliSound;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		heliSound = GetComponent<AudioSource> ();
		heliSound.enabled = false;
	}

	void Update () {

		if (TurnOn) {

			heliSound.enabled = true;
			heliSound.pitch = 1 + Input.GetAxis ("Vertical") * 0.5f;

			frontPropeller.transform.Rotate (0, 15, 0);
			backPropeller.transform.Rotate (20, 0, 0);

			rb.AddForce (transform.up * 500 * Input.GetAxisRaw ("Vertical"));

			frontPropeller.transform.localEulerAngles += new Vector3 (0, Input.GetAxis ("Vertical") * 3, 0);

			if (Input.GetAxisRaw ("Vertical") == 0) {
				rb.AddForce (transform.up * 400);
			}
			float rotx = Input.GetAxis ("heliForward");
			float rotz = Input.GetAxis ("Horizontal");
			transform.localEulerAngles = new Vector3 (rotx * 15,
				transform.localEulerAngles.y,
				rotz * 15);
			transform.localEulerAngles += new Vector3 (0, Input.GetAxis ("heliRight") * 1, 0);

			if (Input.GetAxisRaw ("heliForward") == -1) {
				rb.AddForce (-transform.forward * 30);
			}

			if (Input.GetAxisRaw ("heliForward") == 1) {
				rb.AddForce (transform.forward * 60);
			}
		} else {
			heliSound.enabled = false;
		}
	}
}