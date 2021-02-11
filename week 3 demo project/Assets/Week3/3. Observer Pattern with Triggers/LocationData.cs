﻿/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//need to add this using statement
using UnityEngine.UI;

namespace ObserverPatternCollide
{
    //Attach this to an empty GameObject in the scene
    public class LocationData: MonoBehaviour, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public List<Location> locations = new List<Location>(); 

        public void RegisterObserver(IObserver observer)
        {
            //Add observer to list of observers
            observers.Add(observer);

            if (locations != null)
            {
                //Updates data for newly added observer
                observer.UpdateData(locations);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                //include data as parameters to UpdateData
                observer.UpdateData(locations);
                Debug.Log("UpdateData was called from Notify Observers");
            }
        }

        public void AddLocation(Location location)
        {
            //Add location to list of locations
            locations.Add(location);

            NotifyObservers();
        }


    }
}
