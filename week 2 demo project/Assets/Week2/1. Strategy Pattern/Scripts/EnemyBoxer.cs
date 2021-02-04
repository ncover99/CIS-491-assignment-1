/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class EnemyBoxer : Enemy
    {
        public EnemyBoxer()
        {
            AttackBehavior = new AttackPunch();
            SpecialAbilityBehavior = new SpecialAbilityBodySlam();
        }
        public override void Die()
        {
            Debug.Log("The boxer dies.");
            //add death animations and particle effects for boxer death here
        }
    }

}