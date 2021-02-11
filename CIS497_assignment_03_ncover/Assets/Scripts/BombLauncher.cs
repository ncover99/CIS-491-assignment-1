/*
 * Nathan Cover
 * Pistol.cs
 * Assignment_02
 * class to handle the pistol weapon object that derives from the firearm superclass. Has its own implementation
 * of the fire method only fire 1 shot per click. Also has its own implementation of the reload method that differs
 * from the shotgun class in that it reloads all of its ammo instantly after a set waiting time after pressing R
 */

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class BombLauncher : Firearm, ISubject
    {
        private List<IObserver> _armedBombs = new List<IObserver>();
        
        protected override void Fire() //pistols implementation of the fire method
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                var temp = Instantiate(bullet, transform.position, transform.rotation);
                temp.GetComponent<Bomb>().SetDetonator(this);
            }
            else
            {
                Debug.Log("OUT OF AMMO");
            }
            
            TriggerLock = true;
        }

        public override void Trigger(bool trigger)
        {
            if( ReloadFlag == false)
                base.Trigger(trigger);
        }

        public override void Reload()
        {
            if (CurrentAmmo < AmmoPerMag && ReloadFlag == false)
            {
                ReloadFlag = true;
                StartCoroutine(ReloadTimer());
                Debug.Log("RELOADING");
            }
        }

        private IEnumerator ReloadTimer()
        {
            yield return new WaitForSeconds(ReloadTime);
            CurrentAmmo = AmmoPerMag;
            ReloadFlag = false;
        }

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
            }
            _armedBombs.Clear();
            Debug.Log("Detonating all active bombs");
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
