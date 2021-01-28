using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Week_1__2._OOP_Review_Polymorphism_with_GameObjects
{

    public class Player : MonoBehaviour
    {
        public float speed;

        private void Start()
        {
            speed = 5;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Powerup>() != null)
            {
                //get the powerup using polymorphism - notice that Powerup is the supertype, the abstract class
                Powerup powerup = other.gameObject.GetComponent<Powerup>();
                
                //Calling Activate() on the powerup calls that method for the concrete subtype, the specific powerup that was triggered
                //In this case we use StartCoroutine to call this method because Activate is a coroutine (returns IEnumerator)
                StartCoroutine(powerup.Activate());
            }
        }

        #region Movement

        private float horiztonalInput;
        private float verticalInput;

        void Update()
        {
            Move();
        }

        private void Move()
        {
            //Get Input
            horiztonalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            //Transform with input
            transform.Translate(Vector3.right * horiztonalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        }
        #endregion

    }
}
