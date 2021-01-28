using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Week_1__3._OOP_Review_Polymorphic_List_with_GameObjects
{
    public class Sword : Item
    {
        public string itemName;
        public string description;
        public float damageModifier;
        public bool broken;
        void OnEnable()
        {
            //Set broken to true a random 1/3 of the time
            broken = Random.Range(1, 3) == 1 ? true : false;
        }

        public override void Repair()
        {
            broken = false;

        }

        public override void Break()
        {
            broken = true;
        }
    }
}