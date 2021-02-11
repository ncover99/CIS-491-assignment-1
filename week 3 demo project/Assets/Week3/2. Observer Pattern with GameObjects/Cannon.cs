/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    //Attach this class to the barrel of a cannon prefab
    public class Cannon : MonoBehaviour, IObserver
    {
        bool firing;
        float force;
        ForceMode forceMode;

        //Attach the GameObject holding ForceData to this in the inspector
        public ForceData forceData;

        //Attach the cannonball prefab "core" to this in the the inspector
        public Rigidbody projectile;


        public void UpdateData(bool firing, float force, ForceMode forceMode)
        {
            if (this.firing != firing)
            {
                this.firing = firing;
                UpdateFiring();
            }

            this.force = force;
            this.forceMode = forceMode;

        }
        
        void Start()
        {
            forceData.RegisterObserver(this);
        }

        void UpdateFiring()
        {
            if (firing)
            {
                InvokeRepeating("LaunchProjectile", 0.2f, 2.0f);
            }
            else
            {
                CancelInvoke();
            }
        }

        void LaunchProjectile()
        {
            Rigidbody instance = Instantiate(projectile, transform.position, transform.rotation);

            instance.AddForce(transform.forward * force, forceMode);
        }

    }
}
