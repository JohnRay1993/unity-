using MagicCraft.CraftSystem;
using UnityEngine;

namespace MagicCraft
{
    public class ResourceManager : MonoBehaviour
    {
        [Header("References"), SerializeField] private ResourceContainer containerPrefab;

        private void Start()
        {
            UI.ResourceContainer.Pick += HandleResourcePick;
        }

        private void HandleResourcePick(Resource res)
        {
            Create(res);
        }

        public void Create(Resource res)
        {
            ResourceContainer container = Instantiate(containerPrefab);
            container.Setup(res);
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            container.transform.position = position;
            container.GetComponent<Drag>().FollowMouse(true);
        }
    }
}
