/*
 * Nathan Cover
 * Pistol.cs
 * Assignment_01
 * class to handle the pistol weapon object that derives from the firearm superclass. Has its own implementation
 * of the fire method only fire 1 shot per click. Also has its own implementation of the reload method that differs
 * from the shotgun class in that it reloads all of its ammo instantly after a set waiting time after pressing R
 *
 * instantiates bombs through the objectPooler class now
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_10
{
    public class Pistol : Firearm
    {
        protected override void Fire() //pistols implementation of the fire method
        {
            if (CurrentAmmo > 0)
            {
                Debug.Log("Fire");
                CurrentAmmo--;
                objectPooler.Instantiate("bullet", transform.position, transform.rotation);
                //Instantiate(bullet, transform.position, transform.rotation);   
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
