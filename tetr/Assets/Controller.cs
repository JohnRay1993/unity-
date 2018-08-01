using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] private GameObject[] blocks = new GameObject[4];
    [SerializeField] private Main main;

    // Use this for initialization
    void Start () {
        main.AddNew(blocks);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
