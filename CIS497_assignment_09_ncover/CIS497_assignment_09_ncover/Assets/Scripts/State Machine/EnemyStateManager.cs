/*
 * Nathan Cover
 * EnemyStateManager.cs
 * Assignment_09
 * state machine controller for enemy behavior, allows the ability to call to different enemy actions and to change the current state
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class EnemyStateManager : MonoBehaviour
    {
        public EnemyState IdleState { get; set; }
        public EnemyState ChaseState { get; set; }
        public EnemyState AttackState { get; set; }
        public EnemyState PatrolState { get; set; }
        
        public EnemyState CurrentState { get; set; }
        
        

        // Use this for initialization
        void Start()
        {
            if(IdleState == null)
                IdleState = gameObject.AddComponent<IdleState>();
            if(ChaseState == null)
                ChaseState = gameObject.AddComponent<ChaseState>();
            if(AttackState == null)
                AttackState = gameObject.AddComponent<AttackState>();
            if(PatrolState == null)
                PatrolState = gameObject.AddComponent<PatrolState>();
            
            CurrentState = IdleState;

        }

        
        // Set Enemy States
        public void Chase(Transform target)
        {
            CurrentState.Chase(target);
        }

        public void Patrol()
        {
            CurrentState.Patrol();
        }

        public void Attack(Transform target)
        { 
            CurrentState.Attack(target);
        }
    }    
}