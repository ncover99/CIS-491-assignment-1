using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{

    public class Player : MonoBehaviour
    {
        public PlayerPowerups playerPowerups;

        //this reference is set in the inspector
        public DisplayText displayText;

        private void Awake()
        {
            playerPowerups = new PlayerPowerups();
        }

        private void Start()
        {
            UpdateDisplayText();
        }

        private void OnTriggerEnter(Collider other)
        {
            Pickup pickup = other.gameObject.GetComponent<Pickup>();
            if (pickup != null)
            {
                AddPlayerDecorator(pickup);
            }
        }

        private void AddPlayerDecorator(Pickup pickup)
        {

            switch (pickup.pickupType)
            {
                case Pickup.PickupType.SPEEDUPLARGE:
                    playerPowerups = new PowerupSpeedUpLarge(playerPowerups);
                    break;
                case Pickup.PickupType.SPEEDUPSMALL:
                    playerPowerups = new PowerupSpeedUpSmall(playerPowerups);
                    break;
                case Pickup.PickupType.SPEEDDOWNLARGE:
                    playerPowerups = new PowerupSpeedDownLarge(playerPowerups);
                    break;
                default:
                    break;
            }
        
            UpdateDisplayText();

        }

        public void UpdateDisplayText()
        {
            displayText.Display(playerPowerups);
        }


        //The player speed has been changed to playerPowerups.speed
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
            transform.Translate(Vector3.right * horiztonalInput * Time.deltaTime * playerPowerups.speed);
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerPowerups.speed);
        }
        #endregion

    }
}
