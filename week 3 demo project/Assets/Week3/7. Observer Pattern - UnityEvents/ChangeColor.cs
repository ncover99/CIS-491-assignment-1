/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * with code adapted from https://learn.unity.com/tutorial/events-uh#5c894782edbc2a1410355442
 * and https://docs.unity3d.com/ScriptReference/Random.ColorHSV.html
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPatternUnityEvents
{
    public class ChangeColor : MonoBehaviour
    {
        private SendEventOnClick sendEventOnClickScript;

        private void Awake()
        {
            sendEventOnClickScript = GameObject.FindGameObjectWithTag("Button").GetComponent<SendEventOnClick>();
        }


        void Start()
        {
            //Adds the TurnColor method to our OnButtonClick UnityEvent
            sendEventOnClickScript.OnButtonClick.AddListener(TurnColor);

            //This will add the listener so that it shows up in the inspector,
            //but this only works in the editor and will break when building the game
            //UnityEditor.Events.UnityEventTools.AddPersistentListener(sendEventOnClickScript.OnButtonClick, TurnColor);
        }

        void OnDestroy()
        {
            sendEventOnClickScript.OnButtonClick.RemoveListener(TurnColor);
        }

        // This is the method that is being added to our onClick event
        public void TurnColor()
        {
            // Turn a random, saturated and not-too-dark color
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}