/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternWithGameObjects
{

    //If Enemy extends MonoBehaviour, you can attach its concrete subclasses as Components on GameObjects.
    //Instead of instantiating the classes with the new keyword, 
    //drag the EnemySpider (or EnemyRobot, etc.) script/class onto the GameObject it applies to, 
    //or use AddComponent<EnemySpider>() to add the class at runtime.
    public abstract class Enemy: MonoBehaviour
    {

        public ChangeColorBehavior ChangeColorBehavior { get; set; }


        //Performs the color change behavior. Virtual means this method can be overridden by a subclass.
        public virtual void DoChangeColor() { ChangeColorBehavior.ChangeColor(); }


        //abstract methods must be implemented by concrete sub-classes
        public abstract void Die();

        //Unlike interfaces, abstract classes can have concrete methods
        //These concrete methods are inherited by sub-classes
        public void speak() { Debug.Log("I'm an enemy. Fear me!"); }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoChangeColor();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = gameObject.AddComponent<ChangeColorRed>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = gameObject.AddComponent<ChangeColorBlue>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = gameObject.AddComponent<ChangeColorGreen>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Destroy(GetComponent<ChangeColorBehavior>());
                ChangeColorBehavior = gameObject.AddComponent<ChangeColorYellow>();
            }

        }


    }

}