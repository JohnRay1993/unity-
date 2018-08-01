using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicCraft.CraftSystem;

namespace MagicCraft.UI
{
    public class Book : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Resource[] resources;
        [SerializeField] private ResourceContainer containerPrefab;
        [SerializeField] private Transform containerParent;

        private void Awake()
        {
            Generate();
        }
        private void Generate()
        {
            for (int i = 0; i < resources.Length; i++)
            {
                ResourceContainer container = Instantiate(containerPrefab, containerParent);
                container.Setup(resources[i]);
            }
        }
    }
}