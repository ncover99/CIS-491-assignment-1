using UnityEngine;

namespace Assets.Scripts.Assignment_01
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
