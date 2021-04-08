/*
 * Nathan Cover
 * ObjectPooler.cs
 * Assignment_10
 * Class to handle basic pooling of object, inactive objects are categorized into child game objects of the pooler object that act as "folders"
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Assignment_10
{
    [Serializable]
    public struct Pool
    { 
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    public class ObjectPooler : MonoBehaviour
    {
        // A list of Pool objects based on the Pool class
        public List<Pool> Pools;

        // Dictionary holds a reference to the original prefab as the key, and a queue of its instances
        public Dictionary<string, Queue<GameObject>> PoolDictionary;
        
        public static ObjectPooler instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        
        void Start()
        {
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();

            FillPool();
        }
        
        private void FillPool()
        {
            foreach (Pool pool in Pools)
            {
                // create a container for this pool
                var poolContainer = new GameObject(pool.tag + " container");
                poolContainer.transform.SetParent(this.gameObject.transform);
                
                Queue<GameObject> objectPool = new Queue<GameObject>();

                // create as many instances as specified by pool size
                for (int i = 0; i < pool.size; i++)
                {
                    // Instantiate the prefab (also set in inspector) and assign it to obj
                    GameObject obj = Object.Instantiate(pool.prefab);
                    
                    // add instance to its specific pool container
                    obj.transform.SetParent(poolContainer.transform);
                    
                    // Set obj as inactive
                    obj.SetActive(false);
                    // Enqueue or add obj to the queue of objects (to the back of the line)
                    objectPool.Enqueue(obj);
                }
                // Add the queue of objects to the dictionary of pools with that pool's 
                // string tag (set in inspector) as a label
                PoolDictionary.Add(pool.tag, objectPool);
            }
        }


        public GameObject Instantiate(string tag, Vector3 position, Quaternion rotation, Transform parent = null)
        {

            if(!PoolDictionary.ContainsKey(tag))
            {
                // If you get this error, be sure you set the Pool's tag correctly in the inspector
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                
                return null;
            }
            // Dequeue or remove the object to spawn (from the front of the line)
            GameObject objectToSpawn = PoolDictionary[tag].Dequeue();

            // Set object to spawn to active
            objectToSpawn.SetActive(true);
            // Set the position and rotation of the object to what was passed into SpawnFromPool()
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            // set parent of spawned object
            objectToSpawn.transform.parent = parent;

            // Add the object back to the queue of objects (to the back of the line)
            PoolDictionary[tag].Enqueue(objectToSpawn);

            // Return the object to spawn
            return objectToSpawn;
            

        }
        
        public void Destroy(string tag, GameObject objectToReturn)
        {
            // Set obj as inactive
            objectToReturn.SetActive(false);

            // get the child object that acts as a container for a specific pool
            var temp = gameObject.transform.Find(tag + " container");
            // add the 'destroyed' object back to the pool container
            objectToReturn.transform.SetParent(temp);
            
            // Add the object back to the queue of objects (to the back of the line)
            PoolDictionary[tag].Enqueue(objectToReturn);

        }
    }
}