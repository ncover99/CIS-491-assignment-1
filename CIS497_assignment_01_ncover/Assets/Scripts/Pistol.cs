using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_01
{
    public class Pistol : Firearm
    {
        protected override void Fire() //pistols implementation of the fire method
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                Instantiate(bullet, transform.position, transform.rotation);   
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
    }   
}
