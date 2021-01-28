using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Firearm : MonoBehaviour
{
    [SerializeField] protected int ammoPerMag = 11;
    [SerializeField] protected float roteOfFire = 0.2f;
    protected bool rofFlag = false;
    [SerializeField] protected GameObject bullet;
    [HideInInspector] public bool triggerLock = false;
    
    public abstract void Fire();

    public abstract void Reload();
    public virtual void Trigger(bool trigger)
    {
        if(trigger && triggerLock == false)
            Fire();
        if (trigger == false && triggerLock && rofFlag == false)
            StartCoroutine(RateOfFire());
    }
    
    IEnumerator RateOfFire()
    {
        rofFlag = true;
        yield return new WaitForSeconds(roteOfFire);
        triggerLock = false;
        rofFlag = false;
    }

}
