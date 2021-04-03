/*
 * Nathan Cover
 * AttackState.cs
 * Assignment_09
 * child of EnemyState.cs, handles functionality for enemy attacking, and switching to other states
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class AttackState : EnemyState
    {
        private GameObject _bullet;
        [SerializeField] protected float roteOfFire = 0.5f;
        private bool RofFlag = false;
        protected override void Start()
        {
            base.Start();
            _bullet = Resources.Load<GameObject>("bullet");
        }

        public override void Chase(Transform target)
        {
            print("Enemy is too far away, going back to Chasing");
            StateManager.CurrentState = StateManager.ChaseState;
        }

        public override void Patrol()
        {
            print("Enemy lost the target, going back to patroling");
            StateManager.CurrentState = StateManager.PatrolState;
        }

        public override void Attack(Transform target)
        {
            print("Enemy is already attacking a target");
            // rotate to face target
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var playerPos = Camera.main.WorldToScreenPoint(target.position) - screenPos;
            var angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + -90, Vector3.forward),  Time.deltaTime * 2);
            
            
            // shoot at target
            if (RofFlag == false)
            {
                Instantiate(_bullet, transform.position, transform.rotation);
                StartCoroutine(RateOfFire());
            }
        }
        
        private IEnumerator RateOfFire()
        {
            RofFlag = true;
            yield return new WaitForSeconds(roteOfFire);
            RofFlag = false;
        }
    }   
}
