using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float f = Input.GetAxisRaw("Vertical") * 300;
        transform.Translate(0, 0, 0);
	}
}
