using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m : MonoBehaviour {

	public int speed = 10;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		//float y = Input.GetAxisRaw ("Third");
		float z = 0f;//Input.GetAxisRaw ("Vertical");

		rb.AddForce (new Vector3(x, 0f, z) * speed);
	}
}
