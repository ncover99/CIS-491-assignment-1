/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyPatternWithGameObjects
{

    public class ChangeColorYellow : ChangeColorBehavior
    {
        public override void ChangeColor()
        {
            Debug.Log("Color Change yellow");
            GetComponent<MeshRenderer>().material.color = Color.yellow;

        }
    }

}