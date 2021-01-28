/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPReviewConsole
{
    public class EnemySpider : Enemy
    {
        public override void Die()
        {
            Debug.Log("The spider dies.");
            //could add death animations and particle effects for spider death here
        }
    }

}
