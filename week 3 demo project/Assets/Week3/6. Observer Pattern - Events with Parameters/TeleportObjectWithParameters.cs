/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternEvents
{
    public class TeleportObjectWithParameters : MonoBehaviour
    {
        void OnEnable()
        {
            SendEventOnClickWithParameters.OnClick += Teleport;
        }


        void OnDisable()
        {
            SendEventOnClickWithParameters.OnClick -= Teleport;
        }


        void Teleport(Color newColor, float maxTeleportHeight)
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(1.0f, maxTeleportHeight);
            transform.position = pos;
        }
    }
}