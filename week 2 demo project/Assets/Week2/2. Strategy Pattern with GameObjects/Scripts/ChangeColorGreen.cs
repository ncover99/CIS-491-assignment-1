/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithGameObjects
{
    public class ChangeColorGreen : ChangeColorBehavior
    {
        public override void ChangeColor()
        {
            Debug.Log("Color Change green");
            GetComponent<MeshRenderer>().material.color = Color.green;

        }
    }

}