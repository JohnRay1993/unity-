using UnityEngine;

namespace MagicCraft.CraftSystem
{
    [ExecuteInEditMode]
    public class Cell : MonoBehaviour
    {
        [Header("References"), SerializeField] private SpriteRenderer view;

        [Header("Settings"), SerializeField] private float radius = 0.5f;
        [SerializeField] private Color emptyColor = Color.gray;
        [SerializeField] private Color overlappedColor = Color.yellow;
        [SerializeField] private Color carryColor = Color.green;

        private GameObject dragObj;
        private bool isOverlapping;
        private GameObject carryObj;

        private void Start()
        {
            Drag.Begin += HandleBeginDrag;
            Drag.End += HandleEndDrag;
        }

        private void HandleBeginDrag(GameObject s)
        {
            dragObj = s;

            if (carryObj != s)
                return;

            carryObj.transform.SetParent(null);
            carryObj = null;
        }

        private void HandleEndDrag(GameObject s)
        {
            if(isOverlapping)
            {
                carryObj = s;
                carryObj.transform.SetParent(transform);
                carryObj.transform.localPosition = Vector3.zero;
            }

            dragObj = null;
            isOverlapping = false;
        }

        private void Update()
        {
            CheckOvelapping();
            UpdateColor();
        }

        private void CheckOvelapping()
        {
            if(dragObj == null)
                return;

            float distance = Vector2.Distance(transform.position, dragObj.transform.position);
            isOverlapping = distance <= radius;
        }

        private void UpdateColor()
        {
            if(carryObj != null)
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

