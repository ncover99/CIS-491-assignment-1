/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * with code adapted from https://learn.unity.com/tutorial/events-uh#5c894782edbc2a1410355442
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ObserverPatternUnityEvents
{
    public class SendEventOnClick : MonoBehaviour, IPointerClickHandler
    {
        //UnityEvent is in UnityEngine.Events so we add the using statement above
        //public UnityEvents show up in the inspector and their effects can be set up there
        //The naming convention for events is On and then the event that triggers it
        public UnityEvent OnButtonClick;

        //On click, invoke the UnityEvent
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
        }
    }
}
