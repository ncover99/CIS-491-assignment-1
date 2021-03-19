/*
* Nathan Cover
* Receiver.cs
* assignment 7
* Class that holds functionality, more specifically, movment, for the receiver object, in this case the player.
*/

using UnityEngine;

namespace Assets.Scripts.Assignment_07
{
    public class Receiver : MonoBehaviour
    {
        [SerializeField] private float _stepIncrement = 1f;
        
        void Update()
        {
            // local direction reference
            Debug.DrawRay(transform.position, transform.up, Color.green);
            Debug.DrawRay(transform.position, transform.right, Color.red);
        }
    
        public Vector3 GetCurrentPosition()
        {
            return gameObject.transform.position;
        }
        
        public void Rotate(Vector3 rotation)
        {
            transform.Rotate(rotation.x, rotation.y, rotation.z);
        }

        public void Step(Vector3 dir)
        {
            dir = transform.TransformDirection( dir);
            transform.position = (dir * _stepIncrement) + transform.position;
        }
    }   
}
