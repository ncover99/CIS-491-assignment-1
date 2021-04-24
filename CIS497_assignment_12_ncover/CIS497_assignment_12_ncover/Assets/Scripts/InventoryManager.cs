/*
 * Nathan Cover
 * InventoryManager.cs
 * Assignment_12
 * Hold the first instance of the composite pattern group object and handles the operations of sorting new leaf objects into the inventory tree
 */
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_12
{
    public class InventoryManager : MonoBehaviour
    {
        public ItemGroupComposite Inventory;
        [SerializeField] private Text _inventoryText;

        // Start is called before the first frame update
        void Start()
        {
            if (Inventory == null)
                Inventory = ScriptableObject.CreateInstance<ItemGroupComposite>();
        }
        
        // iterate through the tree and get the names and amounts of each object to draw to the ui
        private void DrawUI()
        {
            string output = "Inventory:" + "\n";
            foreach (InventoryComponant objet in Inventory.InventoryComponant)
            {
                output += objet.Operation() + "\n";
            }

            _inventoryText.text = output;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            var pickup = col.GetComponent<ItemPickup>();
            if (pickup != null)
            {
                AddSort(pickup.GetItem());
                Destroy(col.gameObject);
            }
        }

        // adds an item to the inventory while trying to add it to existing stacks of the same item
        void AddSort(ItemLeaf item)
        {
            if (item.canStack)
            {
                // search for existing container

                bool hasAdded = false;
                // loop through inventory
                foreach (InventoryComponant objet in Inventory.InventoryComponant)
                {
                    // if the object is a group
                    if (objet is ItemGroupComposite)
                    {
                        // if the group is of same name, and is not full
                        if (objet.ItemName == item.ItemName && objet.GetAmount() < objet.GetMaxAmount())
                        {
                            var temp = objet as ItemGroupComposite;
                            temp.Amount += 1;
                            hasAdded = true;
                            objet.Add(item);
                            break;
                        }
                    }
                }

                //couldnt find a stack to add it to so create a new stack
                if (hasAdded == false)
                {
                    var newStack = ScriptableObject.CreateInstance<ItemGroupComposite>();
                    newStack.SetName(item.ItemName);
                    Inventory.Add(newStack);
                    newStack.Add(item);
                    newStack.Amount += 1;
                    newStack.MaxAmount = 2;
                }
            }
            else
            {
                Inventory.Add(item);
            }
            // update the inventory ui
            DrawUI();
        }
    }
}
