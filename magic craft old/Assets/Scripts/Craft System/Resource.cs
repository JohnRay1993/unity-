using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCraft.CraftSystem
{
    [CreateAssetMenu(fileName = "New Resource", menuName = "Resource")]
    public class Resource : ScriptableObject
    {
        public Sprite Image;
        public Color Color;
        public string Name;
        public string Description;
    }
}