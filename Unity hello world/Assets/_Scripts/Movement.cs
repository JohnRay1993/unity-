using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] private float angularSpeed = 180;
	[SerializeField] private float speed = 10;

	private void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Third");
		float z = Input.GetAxisRaw ("Vertical");

		Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0f , y * angularSpeed * Time.deltaTime, 0f));
		transform.rotation *= deltaRotation;

		Vector3 deltaPosition =  (transform.forward * z + transform.right * x) * speed * Time.deltaTime;

		if (deltaPosition.magnitude > 1) deltaPosition.Normalize();

		transform.position += deltaPosition;
	}
}
