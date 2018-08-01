using UnityEngine;
using MagicCraft.CraftSystem;

namespace MagicCraft.UI
{
    public class Book : MonoBehaviour
    {
        [Header("References"), SerializeField] private Resource[] resources;
        [SerializeField] private ResourceContainer containerPrefab;
        [SerializeField] private RectTransform containerParent;

        private void Start()
        {
            Generate();

            ResourceContainer.Pick += HandleResourcePick;
        }

        private void HandleResourcePick(Resource res)
        {
            Close();
        }

        private void Generate()
        {
            for(int i = 0; i < resources.Length; i++)
            {
                ResourceContainer container = Instantiate(containerPrefab, containerParent);
                container.Setup(resources[i]);
            }
        }

        public void Close()
        {
            Vector2 position = containerParent.anchoredPosition;
            position.y = 0.0f;
            containerParent.anchoredPosition = position;

            //containerParent
        }
    }
}
