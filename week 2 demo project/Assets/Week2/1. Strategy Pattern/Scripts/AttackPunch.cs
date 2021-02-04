/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class AttackPunch : IAttackBehavior
    {
        public void Attack()
        {
            Debug.Log("The enemy punches you!");
        }
    }

}