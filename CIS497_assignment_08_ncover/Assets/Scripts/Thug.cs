/*
* Nathan Cover
* Thug.cs
* assignment 8
* child class of NPC.cs to hold functionaly for thugs behavior
*/

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Assignment_08
{
    public class Thug : NPC
     {
         private bool _willMove = true;
     
         public override void Move()
         {
             if (_willMove)
             {
                 int dirSwitch = Random.Range(0, 5);
     
                 switch (dirSwitch)
                 {
                     case 1:
                         if (!Physics.Raycast(transform.position, Vector3.up))
                             StartCoroutine(Step(Vector2.up));
                         break;
                     case 2:
                         if (!Physics.Raycast(transform.position, Vector3.right))
                             StartCoroutine(Step(Vector2.right));
                         break;
                     case 3:
                         if (!Physics.Raycast(transform.position, Vector3.down))
                             StartCoroutine(Step(Vector2.down));
                         break;
                     case 4:
                         if (!Physics.Raycast(transform.position, Vector3.left))
                             StartCoroutine(Step(Vector2.left));
                         break;
                 }
             }
         }
     
         private IEnumerator Step(Vector2 dir)
         {
             float timePassed = 0;
             _willMove = false;
             var targetPos = transform.position + new Vector3(dir.x, dir.y, 0);
             while (timePassed < 1)
             {
                 timePassed += Time.deltaTime;
                 Rb2d.MovePosition(Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime));
                 yield return null;
             }
             
             _willMove = true;
     
         }
         public override void Interact()
         {
             _willMove = false;
             Speak("dont mess with me");
         }
     }
}