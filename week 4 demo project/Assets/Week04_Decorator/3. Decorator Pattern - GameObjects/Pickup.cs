using System.Collections;
using UnityEngine;

namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{
    public class Pickup : MonoBehaviour
    {
        public enum PickupType { SPEEDDOWNLARGE, SPEEDUPLARGE, SPEEDUPSMALL }

        public PickupType pickupType;

    }
}