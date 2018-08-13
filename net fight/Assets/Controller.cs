using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] private Transform FireSpawn;
    [SerializeField] private GameObject FirePrefab;

    private Rigidbody rigidbody;
    private Animator[] a;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        a = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal") * 200 * Time.deltaTime;
        float w = Input.GetAxisRaw("Vertical") * 50 * Time.deltaTime;

        transform.Translate(0, 0, w);
        transform.Rotate(0, h, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        for (int i = 0; i < a.Length; i++)
            if (a[i] != null)
                a[i].SetBool("isMove", Mathf.Abs(w) > 0 ? true : false);

    }

    private void Fire()
    {
        GameObject fire = Instantiate(FirePrefab, FireSpawn.position, FireSpawn.rotation);
        fire.GetComponent<Rigidbody>().velocity = fire.transform.forward * 50;
        Destroy(fire, 3f);
    }
}