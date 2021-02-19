/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{
    //Attach this class to a UI text object to display the text
    public class DisplayText : MonoBehaviour
    {

        [SerializeField] private string textToDisplay;

        public void Display()
        {
            gameObject.GetComponent<Text>().text = textToDisplay;
        }

        public void Display(string text)
        {
            textToDisplay = text;
            Display();
        }

        public void Display(PlayerPowerups playerPowerups)
        {
            textToDisplay = "";
            textToDisplay += "Speed: ";
            textToDisplay += playerPowerups.speed;
            textToDisplay += "\n";
            textToDisplay += "Powerups: ";
            textToDisplay += playerPowerups.powerups;
            Display();
        }    
        
    }
}
