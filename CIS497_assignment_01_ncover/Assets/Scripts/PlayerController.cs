using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_01
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float xMove = 0f;
        [SerializeField] private float yMove = 0f;
        [SerializeField] private Firearm weapon = null;

        private Rigidbody2D rb2d;
        
        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");
            
            
            // rotate to face cursor
            var screenPos = Camera.main.WorldToScreenPoint(transform.position); // player position in camera space
            var mouseDir = Input.mousePosition - screenPos;
            var angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
            
            // just some stuff to help me with directions
            Debug.DrawRay(transform.position, transform.forward * 1, Color.blue);
            Debug.DrawRay(transform.position, transform.up * 1, Color.green);
            Debug.DrawRay(transform.position, transform.right * 1, Color.red);


            if (weapon != null)
            {
                weapon.Trigger(Input.GetButton("Fire1"));

                if (Input.GetButtonDown("Reload"))
                {
                    weapon.Reload();
                }
            }
        }

        void FixedUpdate()
        {
            // movement
            rb2d.MovePosition(rb2d.position + (new Vector2(xMove, yMove) * speed) * Time.fixedDeltaTime);
        }
    }   
}
