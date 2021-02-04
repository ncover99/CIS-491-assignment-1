/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPattern
{
    public class SpecialAbilityBodySlam : ISpecialAbilityBehavior
    {
        public void SpecialAbility()
        {
            Debug.Log("The enemy slams you with its body!");
        }
    }

}