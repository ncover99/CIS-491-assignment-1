/*
 * Nathan Cover
 * InventoryComponant.cs
 * Assignment_12
 * parent class for composite tree classes to hold basic blueprints for what those classes can do
 */
using UnityEngine;

namespace Assets.Scripts.Assignment_12
{
    public abstract class InventoryComponant : ScriptableObject
    {
        public string ItemName;

        public void SetName(string newName)
        {
            this.name = newName;
            this.ItemName = newName;
        }

        public virtual string Operation()
        {
            return ItemName;
        }

        public virtual int GetAmount()
        {
            throw new System.NotSupportedException("GetAmount() is not supported for " + this.GetType().Name);
        }

        public virtual int GetMaxAmount()
        {
            throw new System.NotSupportedException("GetAmount() is not supported for " + this.GetType().Name);
        }

        public virtual void Add(InventoryComponant inventoryComponent)
        {
            throw new System.NotSupportedException("Add() is not supported for " + this.GetType().Name);
        }

        public virtual void Remove(InventoryComponant inventoryComponent)
        {
            throw new System.NotSupportedException("Remove() is not supported for " + this.GetType().Name);
        }
    }
}
