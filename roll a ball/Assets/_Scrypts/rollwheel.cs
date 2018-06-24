using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollwheel : MonoBehaviour {


	void Update () {
		float rotate = Input.GetAxisRaw ("Horizontal");
		Debug.Log (rotate.ToString());
		if (transform.rotation.y <= 30f && transform.rotation.y >= -30f)
			transform.rotation *= Quaternion.Euler (new Vector3(rotate * 90 * Time.deltaTime, 0f, 0f));
	}
}
