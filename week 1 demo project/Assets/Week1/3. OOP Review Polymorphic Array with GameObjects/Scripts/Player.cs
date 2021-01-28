using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Assets.Scripts.Week_1__3._OOP_Review_Polymorphic_List_with_GameObjects
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
            //grab the Item component off the item - this gets the concrete subclass with polymorphism
            Item item = other.gameObject.GetComponent<Item>();

            Debug.Log(item);

            if (item != null)
            {

                if (item is Sword) 
                {
                    //Downcast the item to its concrete subclass
                    Sword sword = item as Sword;
                    //Add it as a component to the player
                    gameObject.AddComponent<Sword>(sword);

                    //Note: this AddComponent<type>(instance) uses an extension method 
                    //with reflection to copy the component from one GameObject to another, 
                    //which is slow, so it is not recommended (notice the lag on pickup),
                    //but it lets us show GetComponentsInChildren<SuperType>() below can make a polymorphic array

                }
                else if (item is Computer) 
                { 
                    Computer computer = item as Computer;
                    gameObject.AddComponent<Computer>(computer);
                }
                


                //Destroy the item gameObject
                Destroy(other.gameObject);
            }

        }



        void Update()
        {
            Move();

            //when spacebar is pressed...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //This uses GetComponentsInChildren<SuperType>() 
                //with polymorphism to get an array of all concrete subtype items:
                Item[] items = GetComponentsInChildren<Item>();

                //repair all items
                foreach (Item item in items)
                {
                    item.Repair();
                }
            }

            //when enter/return key is pressed...
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Item[] items = GetComponentsInChildren<Item>();


                //break all items by setting the broken bool to true
                foreach (Item item in items)
                {
                    item.Break();
                }
            }


        }


        #region Movement

        private float horiztonalInput;
        private float verticalInput;

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
