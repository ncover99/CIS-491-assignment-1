/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternCollide
{
    public interface IObserver
    {
        void UpdateData(List<Location> locations);

    }
}