/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public interface IObserver
    {
        void UpdateData(bool firing, float force, ForceMode forceMode);

    }
}