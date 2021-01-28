using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Week_1__2._OOP_Review_Polymorphism_with_GameObjects
{
    public class SpeedBoostPowerup : Powerup
    {
        private void Awake()
        {
            cooldownTime = 5f;
        }

        public override IEnumerator Activate()
        {
            Debug.Log("speed boost Activated!");

            //Activate the powerup: add 5 to player speed
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speed += 5;

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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speed -= 5;

            //destroy this powerup
            Destroy(this.gameObject);
        }
    }
}