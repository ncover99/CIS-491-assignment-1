/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternEvents
{
    public class TeleportObject : MonoBehaviour
    {
        void OnEnable()
        {
            SendEventOnClick.OnClick += Teleport;
        }


        void OnDisable()
        {
            SendEventOnClick.OnClick -= Teleport;
        }


        void Teleport()
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(1.0f, 4.5f);
            transform.position = pos;
        }
    }
}