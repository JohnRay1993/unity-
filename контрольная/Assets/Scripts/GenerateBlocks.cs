using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {

    [SerializeField] private GameObject block;
    [SerializeField] private float[] X = {-20f, 20f};
    [SerializeField] private float[] Z = { -20f, 20f };

    private float currentTimeRespawn = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTimeRespawn <= 0f)
        {
            GameObject newBlock = Instantiate(block);
            newBlock.transform.position = new Vector3(Random.Range(X[0], X[1]), 0.5f, Random.Range(Z[0], Z[1]));
            currentTimeRespawn = 2f;
        }

        currentTimeRespawn -= Time.deltaTime;
	}
}
