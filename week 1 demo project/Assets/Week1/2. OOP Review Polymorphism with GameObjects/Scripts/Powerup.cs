using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Week_1__2._OOP_Review_Polymorphism_with_GameObjects
{
    public abstract class Powerup : MonoBehaviour
    {
        [SerializeField] protected float cooldownTime;

        public abstract IEnumerator Activate();
        public abstract void Deactivate();

    }
}