/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ObserverPatternWithScriptableObjects
{
    //Attach this class to a UI text object to display the text
    public class DisplayLocationsVisited : MonoBehaviour, IObserver
    {
        //Attach the GameObject holding LocationData to this reference in the inspector
        public LocationData locationData;

        //Do not create a reference like this for static classes
        //public PlayerInfo playerInfo;

        private string textToDisplay;

        void Start()
        {
            textToDisplay = gameObject.GetComponent<Text>().text;

            locationData.RegisterObserver(this);
        }

        public void UpdateData(List<Location> locations)
        {
            textToDisplay = "";
            foreach (Location location in locations)
            {
                textToDisplay += "Location: " + location.locationName + ".\n";
                textToDisplay += "Visited: " + location.visited.ToString() + ".\n";
                textToDisplay += "Experience for discovering: " + location.expForDiscovering.ToString() + ".\n\n";
            }
            textToDisplay += "Total Experience: " + locationData.totalExp.ToString() + ".\n";
            gameObject.GetComponent<Text>().text = this.textToDisplay;
        }
        
    }
}
