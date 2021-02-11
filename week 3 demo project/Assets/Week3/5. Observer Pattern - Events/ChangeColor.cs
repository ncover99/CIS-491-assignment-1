/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * with code adapted from https://learn.unity.com/tutorial/events-uh#5c894782edbc2a1410355442
 * and https://docs.unity3d.com/ScriptReference/Random.ColorHSV.html
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternEvents
{
    public class ChangeColor : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            //Adds the TurnColor method to our onClick event
            SendEventOnClick.OnClick += TurnColor;
        }

        void OnDisable()
        {
            SendEventOnClick.OnClick -= TurnColor;
        }

        // This is the method that is being added to our onClick event
        public void TurnColor()
        {
            // Turn a random, saturated and not-too-dark color
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}