/*
 * Nathan Cover
 * EnemyBehavior.cs
 * Assignment_02
 * Class to handle the most bare bones enemy functionality. any polymorphic abilities are split off into enemy types
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class EnemyBehavior : MonoBehaviour
    {
        private Transform Player;

        [SerializeField] private EnemyType _enemyType;
    
        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.FindWithTag("Player").transform;
            
        }

        // Update is called once per frame
        void Update()
        {
            if(_enemyType == null)
                _enemyType = gameObject.AddComponent<MeleeEnemy>();
                    
            // rotate to face cursor
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var playerPos = Camera.main.WorldToScreenPoint(Player.position) - screenPos;
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
