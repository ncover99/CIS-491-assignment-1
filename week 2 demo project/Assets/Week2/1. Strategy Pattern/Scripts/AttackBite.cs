/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class AttackBite : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("The enemy bites you!");
        }
    }

}