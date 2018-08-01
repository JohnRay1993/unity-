using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MagicCraft.CraftSystem;

namespace MagicCraft.UI
{
    public class ResourceContainer : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private Resource resource;
        [Header("References")]
        [SerializeField] private Image view;

        private void Awake()
        {
            OnValidate();
        }

        public void Setup(Resource resource)
        {
            this.resource = resource;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            view.sprite = resource.Image;
            view.color = resource.Color;
        }

        private void OnValidate()
        {
            if (resource != null)
                UpdateInfo();
        }
    }
}