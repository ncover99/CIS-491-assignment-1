/*
 * Nathan Cover
 * IdleState.cs
 * Assignment_09
 * child of EnemyState.cs, handles functionality for enemy idle state, and switching to other states
 */


using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class IdleState : EnemyState
    {
        public override void Chase(Transform target)
        {
            print("The enemy has not found anything to chase yet");
        }

        public override void Patrol()
        {
            print("the enemy will start looking for something");
            
            // change state to patrolling
            
            // this is causing unity to hang
            StateManager.CurrentState = StateManager.PatrolState;
        }

        public override void Attack(Transform target)
        {
            print("The enemy has not found anything to attack yet");
        }
    }
}
