using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Firearm : MonoBehaviour
{
    [SerializeField] protected int ammoPerMag = 11;
    [SerializeField] protected float roteOfFire = 0.2f;
    [SerializeField] protected GameObject bullet;
    
    public abstract void Fire();

    public abstract void Reload();
    
    
}
