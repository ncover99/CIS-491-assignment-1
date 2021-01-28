using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Week_1__2._OOP_Review_Polymorphism_with_GameObjects
{
    public class ChangeColorGreenPowerup : Powerup
    {
        private Color previousColor;

        private void Awake()
        {
            cooldownTime = 8;
        }

        public override IEnumerator Activate()
        {
            Debug.Log("Color change green activated!");

            //Activate the powerup: save color and set color to green
            previousColor = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.green;

            //set the powerup gameObject to not active to make it invisible and untriggerable
            gameObject.SetActive(false);

            //wait for cooldownTime seconds
            yield return new WaitForSeconds(cooldownTime);

            //then deactivate this powerup
            Deactivate();
        }

        public override void Deactivate()
        {
            //Deactivate the effect of the powerup: reduce player speed by 5
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = previousColor;

            //destroy this powerup
            Destroy(this.gameObject);
        }
    }
}