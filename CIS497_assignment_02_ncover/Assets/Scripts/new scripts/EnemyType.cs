/*
 * Nathan Cover
 * EnemyType.cs
 * Assignment_02
 * Abstract class to inherit from monobehavior instead of using an interface for different types of enemys
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    [RequireComponent(typeof(CanTakeDamage))]
    public abstract class EnemyType : MonoBehaviour
    {
        [SerializeField] protected float Speed = 3f;
        protected Transform PlayerPos;

        // Start is called before the first frame update
        protected void Start()
        {
            PlayerPos = GameObject.FindWithTag("Player").transform;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public float GetSpeed()
        {
            return Speed;
        }

        public abstract void Move();
    }   
}
