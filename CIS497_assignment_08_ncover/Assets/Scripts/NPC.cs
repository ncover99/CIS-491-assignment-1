/*
* Nathan Cover
* NPC.cs
* assignment 8
* abstract class that holds the main logic loop for npcs
*/

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_08
{
    public abstract class NPC : MonoBehaviour
    {
        public Text speakText = null;
        protected Rigidbody2D Rb2d;
        public float speed = 5f;

        protected virtual void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
        }
    
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("NPC"))
            {
                Interact();
            }
        }

        public abstract void Move();

        public abstract void Interact();

        public virtual void Speak(string toSay)
        {
            speakText.text = toSay + "\n" + speakText.text;
        }

        protected void FixedUpdate()
        {
            Move();
        }
    }
}