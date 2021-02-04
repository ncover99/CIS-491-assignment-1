/*
 * Nathan Cover
 * EnemyBehavior.cs
 * Assignment_02
 * Class to handle the most bare bones enemy functionality. any polymorphic abilities are split off into enemy types
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class EnemyBehavior : MonoBehaviour
    {
        private Transform _player;

        [SerializeField] private EnemyType _enemyType;
        private CanTakeDamage _canTakeDamage;
        private bool _lowHealthFlag = false;
    
        // Start is called before the first frame update
        void Start()
        {
            _canTakeDamage = GetComponent<CanTakeDamage>();
            _player = GameObject.FindWithTag("Player").transform;
            if(_enemyType == null)
                _enemyType = gameObject.AddComponent<MeleeEnemy>();
        }

        private void FixedUpdate()
        {
            if(_enemyType != null)
                _enemyType.Move();
        }

        // Update is called once per frame
        void Update()
        {
            // after the enemy has been damaged enough, switch type from ranged to melee and rush the player
            if (_canTakeDamage.Health <= 1 && !_lowHealthFlag)
            {
                _lowHealthFlag = true;
                var x = _enemyType.GetSpeed();
                Destroy(_enemyType);
                _enemyType = gameObject.AddComponent<MeleeEnemy>();
                _enemyType.SetSpeed(x+2);
            }

            // rotate to face cursor
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var playerPos = Camera.main.WorldToScreenPoint(_player.position) - screenPos;
            var angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var temp = other.GetComponent<CanTakeDamage>();
            if (temp != null && other.gameObject.tag == "Player")
            {
                temp.TakeDamage();
            }
        }
    }   
}
