/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    //Attach this class to an empty GameObject in the scene
    public class ForceData: MonoBehaviour, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        private bool firing = true;
        private float force = 55f;
        private ForceMode forceMode = ForceMode.VelocityChange;


        public void RegisterObserver(IObserver observer)
        {
            //Add observer to list of observers
            observers.Add(observer);
            
            //Updates data for newly added observer
            observer.UpdateData(firing, force, forceMode);
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
                observer.UpdateData(firing, force, forceMode);
                Debug.Log("UpdateData was called from Notify Observers");
            }
        }

        public void toggleFiring()
        {
            firing = !firing;
            NotifyObservers();
        }

        public void increaseForce()
        {
            force += 10F;
            NotifyObservers();
        }

        public void decreaseForce()
        {
            force -= 10F;
            NotifyObservers();
        }

        public void changeForceMode()
        {
            switch (forceMode)
            {
                case ForceMode.Acceleration:
                    forceMode = ForceMode.Force;
                    break;
                case ForceMode.Force:
                    forceMode = ForceMode.Impulse;
                    break;
                case ForceMode.Impulse:
                    forceMode = ForceMode.VelocityChange;
                    break;
                default:
                    forceMode = ForceMode.Acceleration;
                    break;
            }
            NotifyObservers();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                toggleFiring();
                Debug.Log("Cannon is firing:" + firing);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                increaseForce();
                Debug.Log("force is now: " + force);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                decreaseForce();
                Debug.Log("force is now: " + force);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                changeForceMode();
                Debug.Log("force mode is now: " + forceMode);
            }
        }

    }
}
