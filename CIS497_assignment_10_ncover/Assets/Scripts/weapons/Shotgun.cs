/*
 * Nathan Cover
 * Shotgun.cs
 * Assignment_01
 * class to handle the shotgun weapon object which derives from the firearm class. uses the firearm
 * class for trigger functions and for base properties but has its own implementation of the Fire() method
 * for shooting multiple projectiles in a cone as well as its own implementation of reload to simulate manually
 * loading shells into a weapon as apposed to replacing a whole magazine like the pistol class.
 *
 * instantiates bombs through the objectPooler class now
 */

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_10
{
    public class Shotgun : Firearm
    {
        [SerializeField] private int _pelletsPerShell = 8;
        [SerializeField] [Range(0, 1)] private float _accuracy = 1f;

        private void Update()
        {
            // just for a visual depiction of the accuracy in editor
            float Angle = Mathf.Lerp(60, 0, _accuracy);
            Quaternion spreadAngleX = Quaternion.AngleAxis(-Angle, new Vector3(0, 0, 1));
            Quaternion spreadAngleY = Quaternion.AngleAxis(Angle, new Vector3(0, 0, 1));
            
            Debug.DrawRay(transform.position, spreadAngleX * transform.up, Color.red);
            Debug.DrawRay(transform.position, spreadAngleY * transform.up, Color.red);

        }
        protected override void Fire() //pistols implementation of the fire method
        {
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
                for (int x = 0; x < _pelletsPerShell; x++)
                {
                    float angle = Mathf.Lerp(60, 0, _accuracy);
                    float randomAngle = Random.Range(-angle, angle);
                    Quaternion rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z + randomAngle);
                    objectPooler.Instantiate("bullet", transform.position, rotation);
                    //Instantiate(bullet, transform.position, rotation);     
                }
            }
            else
            {
                Debug.Log("OUT OF AMMO");
            }
            
            TriggerLock = true;
        }
        

        public override void Reload()
        {
            if (CurrentAmmo < AmmoPerMag && ReloadFlag == false)
            {
                StartCoroutine(ReloadTimer());
                Debug.Log("RELOADING");
            }
        }
        
        private IEnumerator ReloadTimer()
        {
            ReloadFlag = true;
            for (int x = CurrentAmmo; x < AmmoPerMag; x++)
            {
                ReloadFlag = true;
                yield return new WaitForSeconds(ReloadTime);
                CurrentAmmo++;
            }
            ReloadFlag = false;
        }
    }
}
