/*
 * Nathan Cover
 * PlayerCanTakeDamage.cs
 * Assignment_02
 * Inherits from CanTakeDamage.cs adds extra functionality to the can take damage script for player only use by
 * implementing health ui and a gameover screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_02
{
    public class PlayerCanTakeDamge : CanTakeDamage
    {
        [SerializeField] private Text _healthText = null;
    
        // Start is called before the first frame update
        void Start()
        {
            _healthText.text = _health.ToString();
        }

        public override void TakeDamage(int damageToTake)
        {
            base.TakeDamage(damageToTake);
            _healthText.text = _health.ToString();
        }

        protected override void Death()
        {
            _gameManager.GameOver();
        }
    }   
}
