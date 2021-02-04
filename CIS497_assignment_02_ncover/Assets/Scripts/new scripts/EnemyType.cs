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
        [SerializeField] protected float _speed = 3f;
        protected Transform _playerPos;

        // Start is called before the first frame update
        protected void Start()
        {
            _playerPos = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public abstract void Move();
    }   
}
