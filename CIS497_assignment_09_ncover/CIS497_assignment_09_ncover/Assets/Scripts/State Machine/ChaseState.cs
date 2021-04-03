/*
 * Nathan Cover
 * ChaseState.cs
 * Assignment_09
 * child of EnemyState.cs, handles functionality for enemy chasing, and switching to other states
 */

using UnityEngine;


namespace Assets.Scripts.Assignment_09
{
    public class ChaseState : EnemyState
    {
        private Rigidbody2D _rb2d;
        [SerializeField] private float _chaseSpeed = 3f;
        protected override void Start()
        {
            base.Start();
            _rb2d = GetComponent<Rigidbody2D>();
        }
        
        public override void Chase(Transform target)
        {
            // rotate to face target
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var playerPos = Camera.main.WorldToScreenPoint(target.position) - screenPos;
            var angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + -90, Vector3.forward),  Time.deltaTime * 2);
            var playerDir = new Vector2(transform.position.x - target.position.x, 
                transform.position.y - target.position.y).normalized;
            _rb2d.MovePosition(_rb2d.position + (-playerDir * _chaseSpeed) * Time.fixedDeltaTime);   
            
            print("The enemy is already chasing something");
        }

        public override void Patrol()
        {
            print("Enemy is too far away, going back to patrolling");
            StateManager.CurrentState = StateManager.PatrolState;
        }

        public override void Attack(Transform target)
        {
            print("Enemy is within range to attack");
            StateManager.CurrentState = StateManager.AttackState;
        }
    }
}
