/*
* Nathan Cover
* Civilian.cs
* assignment 8
* child class of NPC.cs to hold functionaly for civilian behavior
*/

using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Assignment_08
{
    public class Civilian : NPC
    {
        private Vector2 _moveDir;
        private GameObject _interacted;
        protected override void Start()
        {
            base.Start();
            _moveDir = newDir();
        }
    
        public override void Move()
        {
            //move in the randomized direction
            Rb2d.MovePosition(Rb2d.position + _moveDir * (speed * Time.fixedDeltaTime));
        }
    
        
        // if npc hits another npc then interact, otherwise change the npcs direction
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("NPC"))
            {
                _interacted = other.gameObject;
                Interact();
            }
            else
            {
                _moveDir = Vector2.Reflect(_moveDir, other.contacts[0].normal);
                //_moveDir = newDir();
            }
        }
    
        // get a new randomized direction for the npc to move in
        private Vector2 newDir()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
        
        public override void Interact()
        {
            // npc runs away from thugs and is scared of them
            if (_interacted.GetComponent<Thug>())
            {
                _moveDir = (this.transform.position - _interacted.transform.position).normalized;
                Speak("s-sorry!");   
            }
            // npcs just act as normal around other civilians
            else
            {
                _moveDir = newDir();
                Speak("scuse me");   
            }
        }
    }

}