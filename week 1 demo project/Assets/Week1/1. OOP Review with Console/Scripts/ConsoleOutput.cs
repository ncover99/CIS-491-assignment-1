/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPReviewConsole
{

    public class ConsoleOutput : MonoBehaviour
    {
        public Enemy spidey;

        public Enemy[] enemies = new Enemy[5];

        public List<Enemy> enemiesList = new List<Enemy>();

        public List<ICanPunch> canPunchList = new List<ICanPunch>();

        // Start is called before the first frame update
        void Start()
        {
            //Part 1: One Spider

            Debug.Log("Make a new Spider.");

            spidey = new EnemySpider();

            spidey.Die();


            //Part 2: a polymorphic array of enemies each die
/*
            enemies[0] = new EnemyBoxer();
            enemies[1] = new EnemyRobot();
            enemies[2] = new EnemySpider();
            enemies[3] = new EnemyBoxer();
            enemies[4] = new EnemySpider();

            //the next line causes an index out of bounds exception because the index ranges from 0 to 4
            //enemies[5] = new EnemyRobot();

            foreach (Enemy enemy in enemies)
            {
                if (enemy == null) { break; }

                enemy.Die();
            }
*/

            //Part 3: a polymorphic list of enemies each die
            /*

            //Add 9 enemies to the list
            for (int i = 0; i < 3; i++)
            {
                enemiesList.Add(new EnemyBoxer());
                enemiesList.Add(new EnemyRobot());
                enemiesList.Add(new EnemySpider());
            }

            //The List size expands and contracts as needed, 
            //so adding more will not cause an index out of bounds exception
            enemiesList.Add(new EnemyRobot());

            //Remove enemy at index position 9
            enemiesList.RemoveAt(9);

            //Remove the 3 enemies at positions 6-8
            enemiesList.RemoveRange(6, 3);

            foreach (Enemy enemy in enemiesList)
            {
                if (enemy == null) { break; }
                enemy.Die();
            }
            */

            //Part 4: a polymorphic list of enemies that can punch
            /*
            
            //add 6 attacks to the attacksList
            for (int i = 0; i < 2; i++)
            {

                canPunchList.Add(new EnemyBoxer());
                canPunchList.Add(new EnemyRobot());
                // We can't add the spider to this list because it cannot punch
                //canPunchList.Add(new EnemySpider());
            }

            foreach (ICanPunch canPunch in canPunchList)
            {
                if (canPunch == null) { break; }
                canPunch.Punch();
            }
            */

        }

    }

}