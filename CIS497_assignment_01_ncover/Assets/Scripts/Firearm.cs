using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_01
{
    public abstract class Firearm : MonoBehaviour
    {
        [SerializeField] protected float ReloadTime = 2f;
        [SerializeField] protected int CurrentAmmo;
        [SerializeField] protected int AmmoPerMag = 11;
        [SerializeField] protected float roteOfFire = 0.2f;
        [SerializeField] protected GameObject bullet;
        
        protected bool RofFlag = false;
        protected bool ReloadFlag = false;
        protected bool TriggerLock = false;

        protected void Start()
        {
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
