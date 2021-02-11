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
    public class ChangeColorWithParameters : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            //Adds the TurnColor method to our onClick event
            SendEventOnClickWithParameters.OnClick += TurnColor;
        }

        void OnDisable()
        {
            SendEventOnClickWithParameters.OnClick -= TurnColor;
        }

        // This is the method that is being added to our onClick event
        public void TurnColor(Color newColor, float maxTeleportHeight)
        {
            // Turn a random, saturated and not-too-dark color
            GetComponent<MeshRenderer>().material.color = newColor;
        }
    }
}