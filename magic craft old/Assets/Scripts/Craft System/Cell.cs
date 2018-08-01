using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.CraftSystem
{
    [ExecuteInEditMode]
    public class Cell : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SpriteRenderer view = null;
        [Header("Settings")]
        [SerializeField] private float radius = 0.5f;
        [SerializeField] private Color emptyColor = Color.gray;
        [SerializeField] private Color overlappedColor = Color.yellow;
        [SerializeField] private Color carryColor = Color.green;

        private GameObject dragObj;
        private bool isOverlapping;
        private GameObject carryObj;

        private void Start()
        {
            Drag.Begin += Drag_Begin;
            Drag.End += Drag_End;
        }

        void Drag_Begin(GameObject obj)
        {
            dragObj = obj;

            if (carryObj != obj)
                return;
            
            carryObj.transform.SetParent(null);
            carryObj = null;
        }

        void Drag_End(GameObject obj)
        {
            if (isOverlapping)
            {
                carryObj = obj;
                carryObj.transform.SetParent(transform);
                carryObj.transform.localPosition = Vector3.zero;
            }

            dragObj = null;
            isOverlapping = false;
        }

        private void Update()
        {
            CheckOverlapping();
            UpdateColor();
        }

        private void CheckOverlapping()
        {
            if (dragObj == null)
                return;

            float distance = Vector2.Distance(transform.position, dragObj.transform.position);
            isOverlapping = distance <= radius;
        }

        private void UpdateColor()
        {
            if (carryObj != null)
            {
                view.color = isOverlapping ? overlappedColor : carryColor;
            }
            else
            {
                view.color = isOverlapping ? overlappedColor : emptyColor;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = isOverlapping ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
