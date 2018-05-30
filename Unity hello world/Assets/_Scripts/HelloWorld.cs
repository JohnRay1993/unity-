using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Hello world!1");
	}

	public float speed = 1;

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3(speed * Mathf.Cos(Time.time), speed * Mathf.Sin(Time.time), 0f) * Time.deltaTime;
		transform.rotation = transform.rotation * Quaternion.Euler (new Vector3(80, 80, 80) * Time.deltaTime);
		transform.localScale = transform.localScale + new Vector3 (0.5f, 0.5f, 0.5f) * Time.deltaTime * Mathf.Sin(Time.time);
	}
}
