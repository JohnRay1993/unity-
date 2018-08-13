using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour {

    public Vector3 direction;

    private Vector3 dir;
    private float myTime = 0f;
    private GameObject me;

	// Use this for initialization
	void Start () {
        dir = direction;
        me = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(dir * Time.deltaTime);
        myTime += Time.deltaTime;
        if (myTime > 3f)
            Destroy(me);
	}
}
