/*
* Nathan Cover
* Cop.cs
* assignment 6
* class that derives from NPC.cs, will chase down criminals
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : NPC
{
    private Transform _target;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        transform.gameObject.tag = "Cop";
        this.NpcColor = Color.blue;
        base.Start();
    }

    // find the closest criminal and set it as a target, only updates if the current target is destroyed
    private Transform GetTarget()
    {
        // get all citizens
        var criminals = GameObject.FindGameObjectsWithTag("Criminal");
        if (criminals.Length == 0)
            return null;


        Transform closestCitizen = criminals[0].transform;
        // loop through criminals
        for (int x = 0; x < criminals.Length; x++)
        {
            // if current citizens distance to self is less then the current shortest distance then set this citizen as new closest
            if (Vector2.Distance(transform.position, criminals[x].transform.position) < 
                Vector2.Distance(transform.position, closestCitizen.position))
            {
                closestCitizen = criminals[x].transform;
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
}
