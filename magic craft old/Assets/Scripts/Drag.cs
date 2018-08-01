using System;
using UnityEngine;

namespace MagicCraft
{
    public class Drag : MonoBehaviour
    {
        public static event Action<GameObject> Begin;
        public static event Action<GameObject> End;

        private bool isFollowing;
        private Camera cam;
        private Vector2 offset;

        private void Awake()
        {
            cam = Camera.main;
        }

        public void FollowMouse(bool enable)
        {
            isFollowing = enable;

            if (enable)
            {
                offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);

                if (Begin != null)
                    Begin(gameObject);
            }
            else
            {
                if (End != null)
                    End(gameObject);    
            }
        }

        private void Update()
        {
            if (isFollowing)
                FollowMouse();
        }

        private void FollowMouse()
        {
            Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = worldPos + offset;
        }
    }
}
