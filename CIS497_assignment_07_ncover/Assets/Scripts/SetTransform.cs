/*
* Nathan Cover
* SetTransform.cs
* assignment 7
* Command class that records and holds the transforms of a reciever and changes the recievers transforms when
* the player wants to undo. I thought it was a better idea to have a command class that handles all the transforms
* as a whole rather then different command classes for different types of movment which can quickly get cluttered
*/

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_07
{
    public class SetTransform : ICommand
    {
        private Receiver _receiver;
        private Stack<TransformContainer> _transformHistory;
        
        public SetTransform(Receiver receiver)
        {
            this._receiver = receiver;
            _transformHistory = new Stack<TransformContainer>();
        }

        public int GetStepCount()
        {
            return _transformHistory.Count;
        }

        public void Execute() //record data about the objects transforms
        {
            // store the current values of the receivers transforms in a struct
            var toPush = new TransformContainer();
            toPush.Position = _receiver.transform.position;
            toPush.Rotation = _receiver.transform.rotation;
            toPush.LocalScale = _receiver.transform.localScale;
            
            // push the struct containing the data
            _transformHistory.Push(toPush);
        }

        public void Undo()
        {
            // if there is still stored undo steps
            if (_transformHistory.Count != 0)
            {
                // set transforms of the receiver to an earlier state
                var temp = _transformHistory.Pop();
                _receiver.transform.position = temp.Position;
                _receiver.transform.rotation = temp.Rotation;
                _receiver.transform.localScale = temp.LocalScale;
            }
        }
    }
    
    //Transform is a component not a type so I need a data type to hold its values or else
    //I would just be storing references to the component
    public struct TransformContainer
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 LocalScale { get; set; }
    }
}
