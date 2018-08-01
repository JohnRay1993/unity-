using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    [SerializeField] private GameObject prefab;

    public void CreateOne()
    {
        GameObject newbie = Instantiate(prefab);
        newbie.transform.position = new Vector3(0, 4, 0);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
