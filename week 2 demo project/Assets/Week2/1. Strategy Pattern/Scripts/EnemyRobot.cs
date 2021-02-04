/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class EnemyRobot : Enemy
    {
        public EnemyRobot()
        {
            AttackBehavior = new AttackLaser();
            SpecialAbilityBehavior = new SpecialAbilityBodySlam();
        }

        // We can use an overloaded constructor to pass in 
        // behaviors that are not the defaults above
        public EnemyRobot(IAttackBehavior attack, ISpecialAbilityBehavior specialAbility)
        {
            AttackBehavior = attack;
            SpecialAbilityBehavior = specialAbility;
        }
               
        public override void Die()
        {
            Debug.Log("The robot dies.");
            //add death animations and particle effects for robot death here
        }
    }

}