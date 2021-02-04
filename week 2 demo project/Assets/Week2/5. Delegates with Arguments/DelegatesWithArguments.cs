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
    public class DelegatesWithArguments : MonoBehaviour
    {
        //delegates hold methods
        //this is how we declare a delegate
        public delegate void ChangeColor(Color newColor);
        public ChangeColor onColorChange;

        void Start()
        {
            //The signature of the delegate must match the method being assigned to it
            //So, this line will not work:
            //onColorChange = Task;
            
            //Assigning methods to delegates
            onColorChange = UpdateColor;

            onColorChange(Color.green);
        }

        public void UpdateColor(Color newColor)
        {
            GetComponent<MeshRenderer>().material.color = newColor;
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                onColorChange(Color.red);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                onColorChange(Color.blue);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                onColorChange(Color.green);
            }


        }


    }

}