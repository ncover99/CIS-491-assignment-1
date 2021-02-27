/*
* Nathan Cover
* Citizen.cs
* assignment 5
* class that derives from NPC.cs, will move randomly, gets destroyed if a criminal touches it
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Citizen : NPC
{
    private Vector2 _dirToMove;
    // Start is called before the first frame update
    protected override void Start()
    {
        transform.gameObject.tag = "Citizen";
        // random direction to move in
        _dirToMove = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        this.NpcColor = Color.white;
        base.Start();
    }

    public override void Move()
    {
        //move in the randomized direction
        Rb2d.MovePosition(Rb2d.position + _dirToMove * (Speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // destroy itself if it touches a criminal
        if (other.gameObject.CompareTag("Criminal"))
        {
            Destroy(this.gameObject);
        }
        else //if it touches anything else, randomize the direction in which to move
        {
            _dirToMove = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }
}
