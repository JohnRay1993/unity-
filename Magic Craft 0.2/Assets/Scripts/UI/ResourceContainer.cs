using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MagicCraft.CraftSystem;

namespace MagicCraft.UI
{
    public class ResourceContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static event Action<Resource> Pick;

        [Header("References"), SerializeField] private Image view;
        [Header("Settings"), SerializeField] private float maxPickingTime = 0.4f;
        [Header("Debug"), SerializeField] private Resource res;

        private bool isPicking;
        private float pickingTime;

        public void Setup(Resource res)
        {
            this.res = res;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            view.sprite = res.Image;
            view.color = res.Color;
        }

        private void Update()
        {
            if (!isPicking)
                return;

            pickingTime += Time.deltaTime;
            Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            if(mouseMovement.magnitude >= 0.1f)
            {
                pickingTime = 0.0f;
                return;
            }

            if (pickingTime < maxPickingTime)
                return;

            // Pick?.Invoke(res)
            if (Pick != null)
                Pick(res);

            isPicking = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPicking = true;
            pickingTime = 0.0f;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPicking = false;
        }

        private void Awake()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            if (res != null)
                UpdateInfo();
        }
    }
}
