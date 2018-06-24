using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour {

	[SerializeField] private Path path;
	[SerializeField] private float speed = 5.0f;

	private Transform[] points;
	private int nextPointIndex = 1;//2;
	private float currentTime = 0.0f;

	//private float enemyHealth = 1f;
	private Transform[] enemyHealthPos;

	/*private void Awake()
	{
		GameObject path = GameObject.Find ("Path");
		points = path.GetComponentsInChildren<Transform> ();

		enemyHealthPos = GameObject.Find ("Enemy").GetComponentsInChildren<Transform>();
	}*/

	private void Update()
	{
		Vector3 currentPoint = path[nextPointIndex - 1];
		Vector3 nextPoint = path[nextPointIndex];

		if (nextPointIndex >= path.GetPointCount())	return;



		currentTime += Time.deltaTime;
		float distance = Vector3.Distance (currentPoint, nextPoint);

		if (speed * currentTime >= distance)
			//if (nextPointIndex < points.Length)
		{
			//enemyHealth -= 0.2f;
			//enemyHealthPos [1].localScale = new Vector3 (enemyHealth, 0.3f, 0.1f);

			nextPointIndex++;
			currentTime = 0.0f;
			//transform.rotation = points [nextPointIndex - 1].rotation;
			Quaternion delta = Quaternion.FromToRotation(transform.forward, nextPoint - currentPoint);
			transform.rotation *= delta;
		}


		transform.position = Vector3.Lerp (currentPoint, nextPoint, speed / distance * currentTime);

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Base") {
			Destroy (gameObject);
		}
	}
}
