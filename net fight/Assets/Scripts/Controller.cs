using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

    [SerializeField] private Transform FireSpawn;
    [SerializeField] private GameObject FirePrefab;
    [SerializeField] private GameObject bot;

    private Rigidbody rigidbody;
    private Animator[] a;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        a = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;


        float h = Input.GetAxisRaw("Horizontal") * 200 * Time.deltaTime;
        float w = Input.GetAxisRaw("Vertical") * 50 * Time.deltaTime;

        transform.Translate(0, 0, w);
        transform.Rotate(0, h, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire(w > 0 ? w : 1);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject b = Instantiate(bot);
            b.transform.position = Vector3.zero;
        }

        for (int i = 0; i < a.Length; i++)
            if (a[i] != null)
                a[i].SetBool("isMove", Mathf.Abs(w) > 0 ? true : false);

    }

    [Command]
    private void CmdFire(float speed)
    {
        GameObject fire = Instantiate(FirePrefab, FireSpawn.position, FireSpawn.rotation);
        fire.GetComponent<Rigidbody>().velocity = fire.transform.forward * 50 * speed;
        Destroy(fire, 3f);
    }
}