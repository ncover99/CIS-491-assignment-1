using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class DetonateBombs : MonoBehaviour, ISubject
    {
        private List<IObserver> _armedBombs = new List<IObserver>();
        
        public void RegisterObserver(IObserver bomb)
        {
            //Add observer to list of observers
            _armedBombs.Add(bomb);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (_armedBombs.Contains(observer))
            {
                _armedBombs.Remove(observer);
            }
        }
        
        public void NotifyObservers()
        {
            //detonate all the armed bombs
            foreach (IObserver observer in _armedBombs)
            {
                observer.ReceiveSignal();
                Debug.Log("Detonating all active bombs");
            }
        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NotifyObservers();
            }
        }
    }   
}
