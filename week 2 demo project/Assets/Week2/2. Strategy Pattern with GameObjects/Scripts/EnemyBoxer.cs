/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternWithGameObjects
{
    public class EnemyBoxer : Enemy, IDestroyable
    {
        //Now that Enemy extends Monobehavior,
        //We need to use Awake() rather than a constructor
        public void Awake()
        {
            //And we use gameObject.AddComponent<ChangeColorBlue>(); instead of new
            //to add the ChageColorBlue script/class to the EnemySpider on Awake()
            ChangeColorBehavior = gameObject.AddComponent<ChangeColorRed>();

        }
        public override void Die()
        {
            Debug.Log("The boxer dies.");
            //add death animations and particle effects for boxer death here
            Destroy(gameObject);
        }
    }
}