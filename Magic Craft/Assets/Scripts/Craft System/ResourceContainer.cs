using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.CraftSystem
{
    public class ResourceContainer : MonoBehaviour
    {
        [Header("References"), SerializeField] private SpriteRenderer view;
        [Header("Debug"), SerializeField] private Resource res;

        private void Awake()
        {
            if (res != null)
                UpdateInfo();
        }

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

        private void OnValidate()
        {
            if (res != null)
                UpdateInfo();
        }
    }
}
