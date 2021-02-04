/*
 * Nathan Cover
 * RangedEnemy.cs
 * Assignment_02
 * child of EnemyType.cs holds functionality for ranged enemies, chases the player within a certain distance and shoots
 * at the player until it is out of ammo then the component is destroyed.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class RangedEnemy : EnemyType
    {
        private Rigidbody2D _rb2d;
        [SerializeField] private float _maxDistance = 5f;
        [SerializeField] private int _maxAmmo = 4;
        private int _currentAmmo = 0;
        [SerializeField] private GameObject _bullet = null;
        [SerializeField] private float roteOfFire = 0.5f;
        private bool RofFlag = false;
        private SpriteRenderer _sr2d;
        
        // Start is called before the first frame update
        new void Start()
        {
            base.Start();
            _rb2d = GetComponent<Rigidbody2D>();
            _currentAmmo = _maxAmmo;
            _sr2d = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        private void FixedUpdate()
        {
            Move();
        }
        
        public override void Move()
        {
            // only chase the player up until a certain distance from the player
            // or if the enemy is off screen. to prevent ranged enemies from attacking out of view
            if ((Vector3.Distance(_playerPos.position, transform.position) > _maxDistance) || !_sr2d.isVisible)
            {
                var playerDir = new Vector2(transform.position.x - _playerPos.position.x, 
                    transform.position.y - _playerPos.position.y).normalized;
                _rb2d.MovePosition(_rb2d.position + (-playerDir * _speed) * Time.fixedDeltaTime);   
            }
            else
            {
                // can only attack if standing still
                Attack();
            }
        }

        private void Attack()
        {
            if (_currentAmmo > 0 && RofFlag == false)
            {
                _currentAmmo--;
                Instantiate(_bullet, transform.position, transform.rotation);
                StartCoroutine(RateOfFire());
            }

            if (_currentAmmo <= 0)
            {
                Destroy(this);
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
