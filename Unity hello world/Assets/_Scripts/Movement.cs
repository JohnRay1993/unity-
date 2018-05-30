using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] private float angularSpeed = 180;
	[SerializeField] private float speed = 10;
	[SerializeField] private float jumpSpeed = 30;

	private float verticalSpeed;
	private bool isJumping;

	private void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Third");
		float z = Input.GetAxisRaw ("Vertical");

		if (Input.GetKeyDown (KeyCode.Space)) {
			//verticalSpeed = jumpSpeed;
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
			//isJumping = true;
		}

		Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0f , y * angularSpeed * Time.deltaTime, 0f));
		transform.rotation *= deltaRotation;

		Vector3 deltaPosition =  ((transform.forward * z + transform.right * x) * speed) * Time.deltaTime;

		if (deltaPosition.magnitude > 1) deltaPosition.Normalize();

		transform.position += deltaPosition;

		//verticalSpeed -= gravity * Time.deltaTime;
	}
}
