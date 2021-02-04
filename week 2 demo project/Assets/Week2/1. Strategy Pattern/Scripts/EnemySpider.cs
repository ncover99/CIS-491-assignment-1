/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class EnemySpider : Enemy
    {
        public EnemySpider()
        {
            AttackBehavior = new AttackBite();
            SpecialAbilityBehavior = new SpecialAbilityWebSpray();

        }
        public override void Die()
        {
            Debug.Log("The spider dies.");
            //add death animations and particle effects for spider death here
        }
    }

}