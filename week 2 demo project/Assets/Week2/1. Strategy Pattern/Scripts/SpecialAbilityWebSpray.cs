/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{

    public class SpecialAbilityWebSpray : ISpecialAbilityBehavior
    {
        public void SpecialAbility()
        {
            Debug.Log("The enemy sprays you with sticky webs!");
        }
    }

}