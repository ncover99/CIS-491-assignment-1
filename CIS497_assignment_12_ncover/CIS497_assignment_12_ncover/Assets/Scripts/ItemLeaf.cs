/*
 * Nathan Cover
 * ItemLeaf.cs
 * Assignment_12
 * leaf class to hold items in the composite pattern tree
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_12
{
    [CreateAssetMenu(fileName = "New Container Object", menuName = "Inventory System/Item")]
    public class ItemLeaf : InventoryComponant
    {
        public bool canStack;
        public GameObject Prefab;

        public GameObject GetPrefab()
        {
            return Prefab;
        }
    }
}
