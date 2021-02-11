/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPatternCollide
{
    //Attach this class to GameObjects with colliders in the scene
    public class Location : MonoBehaviour
    {
        public string locationName;
        public bool visited;
        public int expForDiscovering;
        public Vector3 locationPosition;

        //Attach the GameObject holding LocationData to this reference in the inspector
        public LocationData locationData;

        //Do not create a reference like this for static classes
        //public PlayerInfo playerInfo;

        public void Start()
        {
            locationPosition = gameObject.transform.position;
            locationData.AddLocation(this);
        }

        //This is called when the Player enters the trigger this script is attached to
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && visited == false)
            {
                visited = true;
                PlayerInfo.totalExp += this.expForDiscovering;
                locationData.NotifyObservers();
            }
            
        }

    }
}