using System.Collections;
using UnityEngine;

namespace OOPReviewConsole
{

    public class EnemyBoxer : Enemy, ICanPunch
    {
        public override void Die()
        {
            Debug.Log("The boxer dies.");
            //could add death animations and particle effects for boxer death here
        }

        public void Punch()
        {
            Debug.Log("The boxer punches.");
            //could add punch animations and sound effects here
        }
    }
}