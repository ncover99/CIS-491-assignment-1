/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{

    public class AttackLaser : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("The enemy shoots you with a LASER BEAM!");
        }
    }

}