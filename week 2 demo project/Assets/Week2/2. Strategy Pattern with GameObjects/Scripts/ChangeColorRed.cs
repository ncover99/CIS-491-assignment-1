/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;


namespace StrategyPatternWithGameObjects
{
    public class ChangeColorRed : ChangeColorBehavior
    {
        public override void ChangeColor()
        {
            Debug.Log("Color Change red");
            GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }

}