/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 * with code adapted from GameDevHQ
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FakingStrategyPatternWithDelegates
{
    //It's faking the pattern because we're only switching a method, not a whole class
    public class FakingStrategyPatternWithDelegates : MonoBehaviour
    {
        //delegates hold methods
        //this is how we declare a delegate
        public delegate void ChangeColor();
        public ChangeColor onColorChange;

        void Start()
        {
            //The signature of the delegate must match the method being assigned to it
            //So, this line will not work:
            //onColorChange = Task;
            
            //Assigning methods to delegates
            onColorChange = UpdateColorGreen;

            onColorChange();
        }

        public void UpdateColorRed()
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void UpdateColorGreen()
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        public void UpdateColorBlue()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        public void UpdateColorYellow()
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //set the delegate
                onColorChange = UpdateColorRed;
                //call the delegate
                onColorChange();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //set the delegate
                onColorChange = UpdateColorBlue;
                //call the delegate
                onColorChange();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //set the delegate
                onColorChange = UpdateColorGreen;
                //call the delegate
                onColorChange();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //set the delegate
                onColorChange = UpdateColorYellow;
                //call the delegate
                onColorChange();
            }

        }


    }

}