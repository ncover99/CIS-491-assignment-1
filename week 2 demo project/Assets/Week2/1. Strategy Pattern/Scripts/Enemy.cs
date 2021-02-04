/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{

    public abstract class Enemy
    {
        public IAttackBehavior AttackBehavior { get; set; }
        public ISpecialAbilityBehavior SpecialAbilityBehavior { get; set; }

        //Performs the attack behavior.  Virtual means this method can be overridden by a subclass.
        public virtual void DoAttack() { AttackBehavior.Attack(); }

        //Performs the special ability behavior.
        public virtual void DoSpecialAbility() { SpecialAbilityBehavior.SpecialAbility(); }

        /*  //this is not needed because we have default getters and setters on the property above
        public void setAttackBehavior (IAttackBehavior ab)
        {
            attackBehavior = ab;
        }
        */

        //abstract methods must be implemented by concrete sub-classes
        public abstract void Die();

        //Unlike interfaces, abstract classes can have concrete methods
        //These concrete methods are inherited by sub-classes
        public void speak() { Debug.Log("I'm an enemy. Fear me!"); }

    }

}