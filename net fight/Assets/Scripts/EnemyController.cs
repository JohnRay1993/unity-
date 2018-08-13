using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private GameObject player;  //which kill

	// Use this for initialization
	void Start () {
        GetPlayer();
	}

    private void GetPlayer()
    {
        player = FindObjectOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            GetPlayer();

        int dir = 0;
        if (Vector3.Distance(transform.position, player.transform.position) > 0.1f)
            dir = -1;
        if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
            dir = 1;
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));

        transform.Rotate(0, dir * Time.deltaTime * 20, 0);
	}
}
