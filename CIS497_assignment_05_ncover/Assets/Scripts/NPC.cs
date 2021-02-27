/*
* Nathan Cover
* NPC.cs
* assignment 5
* abstract class for basic NPC behavior/ properties
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    protected string NpcType { get; set; }
    public Color NpcColor { get; set; }
    protected Rigidbody2D Rb2d;
    protected MeshRenderer Mr2d;
    protected float Speed = 5;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Mr2d = GetComponent<MeshRenderer>();
        Mr2d.material.SetColor("_Color", NpcColor);
       Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        Move();
    }

    // method to be overriden
    public virtual void Move()
    {
        //TODO
    }
}
