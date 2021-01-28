using System.Collections;
using UnityEngine;

namespace OOPReviewConsole
{

    public class EnemyRobot : Enemy, ICanPunch
    {
        public override void Die()
        {
            Debug.Log("The robot dies.");
            //could add death animation and particle effects for robot death here
        }

        public void Punch()
        {
            Debug.Log("The robot punches.");
            //could add punch animation and sound effect here
        }

    }

}