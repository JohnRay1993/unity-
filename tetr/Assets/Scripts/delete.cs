using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

    public GameObject go;

    private float dt = 1f;
    private bool done = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dt <= 0f)
        {
            if (!done)
            {
                transform.SetParent(null);
                done = true;
                go.transform.position = Vector3.right;
            }

        }
        else
            dt -= Time.deltaTime;
		
	}
}
