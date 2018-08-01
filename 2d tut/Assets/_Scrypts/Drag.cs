using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
	private bool isFollowing = false;
	private Camera cam;
	private Vector2 offset;

	private void Start(){
		cam = Camera.main;
	}

	public void FollowCursor(bool enabled)
	{
		isFollowing = enabled;
		if (enabled) {
			offset = transform.position - cam.ScreenToWorldPoint (Input.mousePosition);
		}
        else
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, 1f);
            Debug.Log(targets.Length);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == "Players")
                {
                    Debug.Log("GUTCHA!");
                    continue;
                }
            }
        }
	}

	private void Update()
	{
		if (isFollowing)
			FollowCursor();
	}

	private void FollowCursor()
	{
		Vector2 worldPos = cam.ScreenToWorldPoint (Input.mousePosition);
		transform.position = worldPos + offset;
	}
}
