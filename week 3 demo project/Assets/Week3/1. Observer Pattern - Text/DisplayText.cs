/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ObserverPatternText
{
    //Attach this class to a UI text object to display the text
    public class DisplayText : MonoBehaviour, IObserver
    {
        //Attach the GameObject holding TextData to this reference in the inspector
        public TextData textData;

        private string textToDisplay;

        void Start()
        {
            this.textToDisplay = gameObject.GetComponent<Text>().text;

            textData.RegisterObserver(this);
        }
        
        public void UpdateData(string text)
        {
            this.textToDisplay = text;
            gameObject.GetComponent<Text>().text = this.textToDisplay;
        }
        
        

    }
}
