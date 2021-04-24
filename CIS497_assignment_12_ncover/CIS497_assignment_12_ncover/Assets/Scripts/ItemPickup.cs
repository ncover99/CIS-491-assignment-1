/*
 * Nathan Cover
 * ItemPickup.cs
 * Assignment_12
 * Class to hold scriptable objects as pickups with a getter to get said object from another class
 */
using UnityEngine;

namespace Assets.Scripts.Assignment_12
{
    public class ItemPickup : MonoBehaviour
    {
        public ItemLeaf Item;

        public ItemLeaf GetItem()
        {
            return Item;
        }
    }
}
