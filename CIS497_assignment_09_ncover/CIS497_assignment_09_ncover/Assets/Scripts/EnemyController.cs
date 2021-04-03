/*
 * Nathan Cover
 * EnemyController.cs
 * Assignment_09
 * Class the calling of different actions to the enemy's state machine
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_09
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyStateManager _enemyStateMachine = null;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _attackDistance = 1f;
        private float _targetDis;

        // Update is called once per frame
        private void Update()
        {
            // no target, patrol and do nothing else
            if (_target == null)
            {
                _enemyStateMachine.CurrentState.Patrol();
                return;
            }

            _targetDis = Vector3.Distance(_target.transform.position, transform.position);
            
            // target is within attack range
            if (_targetDis <= _attackDistance)
            {
                _enemyStateMachine.CurrentState.Attack(_target.transform);
            }
            else
            {
                _enemyStateMachine.CurrentState.Chase(_target.transform);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("something in vision cone");
            // target detected
            if (other.gameObject.tag == "Player")
            {
                _target = other.gameObject;
                //_enemyStateMachine.CurrentState.Chase(_target.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // if the current target leaves line of site, then then dereference the target
            if (other.gameObject == _target)
            {
                _target = null;
            }
        }
    }   
}
