/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithGameObjects
{
    public class ChangeColorBlue : ChangeColorBehavior
    {
        public override void ChangeColor()
        {
            Debug.Log("Color Change blue");
            GetComponent<MeshRenderer>().material.color = Color.blue;

        }
    }

}