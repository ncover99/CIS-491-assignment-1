/*
* Nathan Cover
* Criminal.cs
* assignment 5
* class that derives from NPC.cs, will chase down citizens. gets destroyed if a cop touches it
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal : NPC
{
    private Transform _target;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        transform.gameObject.tag = "Criminal";
        this.NpcColor = Color.red;
        base.Start();
    }

    // find the closest citizen and set it as a target, only updates if the current target is destroyed
    private Transform GetTarget()
    {
        // get all citizens
        var citizens = GameObject.FindGameObjectsWithTag("Citizen");
        if (citizens.Length == 0)
            return null;


        Transform closestCitizen = citizens[0].transform;
        // loop through citizens
        foreach (var t in citizens)
        {
            // if current citizens distance to self is less then the current shortest distance then set this citizen as new closest
            if (Vector2.Distance(transform.position, t.transform.position) < 
                Vector2.Distance(transform.position, closestCitizen.position))
            {
                closestCitizen = t.transform;
            }
        }

        return closestCitizen;
    }

    // move towards the current target if there is one
    public override void Move()
    {
        if(_target == null)
            _target = GetTarget();

        if (_target != null)
        {
            var targetDir = Vector2.MoveTowards(Rb2d.position, _target.position, Time.deltaTime * Speed);
            Rb2d.MovePosition(targetDir);   
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // destroy self if it touches a cop
        if (other.gameObject.CompareTag("Cop"))
        {
            Destroy(this.gameObject);
        }
    }
}
