/*
 * Nathan Cover
 * ItemGroupComposite.cs
 * Assignment_12
 * group class to hold leafs and other groups in the composite pattern tree
 */

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_12
{
    [CreateAssetMenu(fileName = "New Container Object", menuName = "Inventory System/Container")]
    public class ItemGroupComposite : InventoryComponant
    {
        public List<InventoryComponant> InventoryComponant = new List<InventoryComponant>();
        public int Amount;
        public int MaxAmount;

        public override int GetAmount()
        {
            return Amount;
        }

        public override string Operation()
        {
            return ItemName + "(" + Amount + ")";
        }
        
        public override int GetMaxAmount()
        {
            return MaxAmount;
        }

        public override void Add(InventoryComponant inventoryComponent)
        {
            InventoryComponant.Add(inventoryComponent);
        }

        public override void Remove(InventoryComponant inventoryComponent)
        {
            InventoryComponant.Remove(inventoryComponent);
        }
    }
}
