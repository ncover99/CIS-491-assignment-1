using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Firearm
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire() //pistols implementation of the fire method
    {
        triggerLock = true;
        Instantiate(bullet, transform.position, transform.rotation);
    }

    public override void Reload()
    {
        //TODO
    }
}
