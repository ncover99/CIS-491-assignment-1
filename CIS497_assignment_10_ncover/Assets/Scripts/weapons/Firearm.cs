/*
 * Nathan Cover
 * Firearm.cs
 * Assignment_01
 * abstract superclass for firearm objects containing base functionality for a
 * trigger system and prototype methods for other functionality as well as customizable properties
 *
 * removed variables that reference what bullet gets instantiated
 * added an object pooler variable to get used by sub classes
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_10
{
    public abstract class Firearm : MonoBehaviour
    {
        protected ObjectPooler objectPooler;
        [SerializeField] protected float ReloadTime = 2f;
        [SerializeField] protected int CurrentAmmo;
        [SerializeField] protected int AmmoPerMag = 11;
        [SerializeField] protected float roteOfFire = 0.2f;

        protected bool RofFlag = false;
        protected bool ReloadFlag = false;
        protected bool TriggerLock = false;

        protected void Start()
        {
            objectPooler = ObjectPooler.instance;
            CurrentAmmo = AmmoPerMag;
        }
        
        protected abstract void Fire();

        public abstract void Reload();
        
        public virtual void Trigger(bool trigger)
        {
            if(trigger && TriggerLock == false)
                Fire();
            if (trigger == false && TriggerLock && RofFlag == false)
                StartCoroutine(RateOfFire());
        }
    
        private IEnumerator RateOfFire()
        {
            RofFlag = true;
            yield return new WaitForSeconds(roteOfFire);
            TriggerLock = false;
            RofFlag = false;
        }

    }   
}
