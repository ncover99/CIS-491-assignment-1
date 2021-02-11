/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * with code adapted from https://learn.unity.com/tutorial/events-uh#5c894782edbc2a1410355442
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternEvents
{
    public class SendEventOnClickWithParameters : MonoBehaviour
    {
        /* Create a delegate type called ClickAction.
         * Any method we wish to subscribe to our event must
         * have a matching method signature to the one put here, 
         * meaning it must take these parameters and return void.
         */
        public delegate void ClickAction(Color newColor, float maxTeleportHeight);

        /* Create an event variable that allows methods to be added.
         * This event is static so we can use it outside of the class 
         * without instantiating this class.
         * 
         */
        public static event ClickAction OnClick;

        public void ButtonClick()
        {
            if (OnClick != null)
            {
                OnClick(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 4.5F);
            }
        }
    }
}
