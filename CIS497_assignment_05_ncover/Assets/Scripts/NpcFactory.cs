/*
* Nathan Cover
* NpcFactory.cs
* assignment 5
* Factory class used to generate npcs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFactory : MonoBehaviour
{
    [SerializeField] private GameObject NpcBase;
    private GameObject npcToSpawn;
    public GameObject CreateNpc(string type)
    {
        // have to create an instance of the base prefab, if i dont it permanently adds the components to the base
        // prefab which results ina massive stack of prefabs
        npcToSpawn = Instantiate(NpcBase);

        if (type.Equals("Cop"))
        {
            Debug.Log("Factory sending: Cop");
            npcToSpawn.AddComponent<Cop>();
        }
        else if (type.Equals("Criminal"))
        {
            Debug.Log("Factory sending: Criminal");
            npcToSpawn.AddComponent<Criminal>();
        }
        else // citizen by default
        {
            Debug.Log("Factory sending: Citizen");
            npcToSpawn.AddComponent<Citizen>();
        }
        return npcToSpawn;
    }
}
