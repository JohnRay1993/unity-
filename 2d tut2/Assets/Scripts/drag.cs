using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {
    
    private bool isFollowing = false;
    private Camera cam;
    private Vector2 offset;

    private void Start()
    {
        cam = Camera.main;
    }

    public void FollowCursor(bool enabled)
    {
        isFollowing = enabled;
        if (enabled)
        {
            offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            GameObject[] players =  GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {
                float dist = Vector2.Distance(transform.position, players[i].transform.position);
                if (dist == 0f)
                    continue;
                if (dist <= 1f)
                    transform.position = players[i].transform.position;
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
        Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldPos + offset;
    }
}
