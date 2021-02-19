/* Exampcle Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * This example inspired by Anton Rynkovoy https://gist.github.com/antonrynkovoy/a9e7f3776fcaff6a7de667600f3d3110
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorPattern
{
    public class CharacterCreator : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Character character = new RaceTroll();
            Debug.Log(character.GetDescription() + " does " +
                character.GetDamage() + " damage.");

            Character character2 = new RaceElf();
            character2 = new ProfessionWarrior(character2);
            character2 = new ProfessionWizard(character2);
            Debug.Log(character2.GetDescription() + " does " +
                character2.GetDamage() + " damage.");

            Character character3 = new RaceTroll();
            character3 = new ProfessionWarrior(character3);
            character3 = new ProfessionWarrior(character3);
            character3 = new ProfessionWizard(character3);
            Debug.Log(character3.GetDescription() + " does " +
                character3.GetDamage() + " damage.");

        }

        // Update is called once per frame
        /*    void Update()
            {

            }*/
    }
}