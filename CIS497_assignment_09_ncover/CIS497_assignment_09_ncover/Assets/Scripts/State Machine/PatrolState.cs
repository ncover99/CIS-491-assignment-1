/*
 * Nathan Cover
 * PatrolState.cs
 * Assignment_09
 * child of EnemyState.cs, handles functionality for enemy patrolling, and switching to other states
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class PatrolState : EnemyState
    {
        private bool _willMove = true;
        [SerializeField] private float _stepSpeed = 5f;
        private Rigidbody2D _rb2d;

        protected override void Start()
        {
            base.Start();
            _rb2d = GetComponent<Rigidbody2D>();
        }
        
        public override void Chase(Transform target)
        {
            print("The enemy has found something and will begin chasing");
            
            // code to chase something here
            
            StateManager.CurrentState = StateManager.ChaseState;
        }

        public override void Patrol()
        {
            print("The enemy is already patrolling");
            
            if (_willMove)
            {
                int dirSwitch = Random.Range(0, 5);
     
                switch (dirSwitch)
                {
                    case 1:
                        if (!Physics.Raycast(transform.position, Vector3.up))
                            StartCoroutine(Step(Vector2.up));
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        break;
                    case 2:
                        if (!Physics.Raycast(transform.position, Vector3.right))
                            StartCoroutine(Step(Vector2.right));
                        transform.eulerAngles = new Vector3(0, 0, 270);
                        break;
                    case 3:
                        if (!Physics.Raycast(transform.position, Vector3.down))
                            transform.eulerAngles = new Vector3(0, 0, 180);
                            StartCoroutine(Step(Vector2.down));
                        break;
                    case 4:
                        if (!Physics.Raycast(transform.position, Vector3.left))
                            transform.eulerAngles = new Vector3(0,0,90);
                            StartCoroutine(Step(Vector2.left));
                        break;
                }
            }
        }

        public override void Attack(Transform target)
        {
            print("The enemy is patrolling and has not found anything to attack");
        }
        
        private IEnumerator Step(Vector2 dir)
        {
            float timePassed = 0;
            _willMove = false;
            var targetPos = transform.position + new Vector3(dir.x, dir.y, 0);
            while (timePassed < 1)
            {
                timePassed += Time.deltaTime;
                _rb2d.MovePosition(Vector3.MoveTowards(transform.position, targetPos, _stepSpeed * Time.fixedDeltaTime));
                yield return null;
            }
             
            _willMove = true;
     
        }
    }
}