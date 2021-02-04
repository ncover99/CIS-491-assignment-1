/*
 * Nathan Cover
 * ItemPickup.cs
 * Assignment_02
 * Class to handle attaching gameObjects to another gameObjects, in this case it is called from
 * OnTriggerEnter as a pickup in the scene. I chose going this approach over using the GetCopyOf() and AddComponent
 * Functions from the demo project because different weapons could be stored as different child objects
 * allowing switching much more easily in the future.
 */

using UnityEngine;

namespace Assets.Scripts.Assignment_02
{
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private GameObject objToGet = null;

        public virtual Transform GetItem(Transform parent)
        {
            var newInstance = Instantiate(objToGet, transform.position, Quaternion.identity);
            
            // attach the object to the parent
            newInstance.transform.parent = parent;
            
            // reset transforms
            newInstance.transform.localPosition = new Vector3(0,0,0);
            newInstance.transform.localRotation = Quaternion.identity;
            newInstance.transform.localScale = new Vector3(1,1,1);
            
            Destroy(gameObject);
            return newInstance.transform;
        }
    }   
}
