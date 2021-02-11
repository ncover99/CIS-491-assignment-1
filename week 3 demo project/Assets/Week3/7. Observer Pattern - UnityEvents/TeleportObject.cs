/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternUnityEvents
{
    public class TeleportObject : MonoBehaviour
    {
        private SendEventOnClick sendEventOnClickScript;

        private void Awake()
        {
            sendEventOnClickScript = GameObject.FindGameObjectWithTag("Button").GetComponent<SendEventOnClick>();
        }

        void Start()
        {
            //Adds the Teleport method to our OnButtonClick UnityEvent
            sendEventOnClickScript.OnButtonClick.AddListener(Teleport);

            //This will add the listener so that it shows up in the inspector,
            //but this only works in the editor and will break when building the game
            //UnityEditor.Events.UnityEventTools.AddPersistentListener(sendEventOnClickScript.OnButtonClick, Teleport);

        }


        void OnDestroy()
        {
            sendEventOnClickScript.OnButtonClick.RemoveListener(Teleport);
        }


        void Teleport()
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(1.0f, 4.5f);
            transform.position = pos;
        }
    }
}