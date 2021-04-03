/*
 * Nathan Cover
 * AttackState.cs
 * Assignment_09
 * interface for different enemy state machine states
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public abstract class EnemyState : MonoBehaviour
    {
        protected EnemyStateManager StateManager;

        protected virtual void Start()
        {
            StateManager = GetComponent<EnemyStateManager>();
        }
        public abstract void Chase(Transform target);
        public abstract void Patrol();
        public abstract void Attack(Transform target);
    }
}

