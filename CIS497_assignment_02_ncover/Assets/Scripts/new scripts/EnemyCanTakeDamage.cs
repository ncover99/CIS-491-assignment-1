/*
 * Nathan Cover
 * EnemyCanTakeDamage.cs
 * Assignment_02
 * Inherits from CanTakeDamage.cs adds extra functionality to update the score/ kill count of enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_02
{
    public class EnemyCanTakeDamage : CanTakeDamage
    {

        protected override void Death()
        {
            _gameManager.UpdateKills();
            base.Death();
        }
    }   
}
