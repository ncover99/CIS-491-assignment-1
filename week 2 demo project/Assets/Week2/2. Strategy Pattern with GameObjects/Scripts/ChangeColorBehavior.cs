/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using UnityEngine;

namespace StrategyPatternWithGameObjects
{
    //By making the abstract parent class extend MonoBehaviour,
    //it can be called with Destroy(GetComponent<ChangeColorBehavior>()); in the Enemy script.
    //Interfaces cannot extend MonoBehaviour, but Abstract Classes can.
    //And GetComponent<type>() can only be called on classes that extend MonoBehaviour.
    public abstract class ChangeColorBehavior : MonoBehaviour
    {
        public abstract void ChangeColor();
    }

}