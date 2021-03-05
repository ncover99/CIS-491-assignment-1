/*
* Nathan Cover
* NeutralCreator.cs
* assignment 6
* factory class to spawn neutral type npcs
*/

using UnityEngine;

public class NeutralCreator : NPCCreator
{

    public override GameObject CreateNpc(GameObject baseObj)
    {
        baseObj.AddComponent<Citizen>();
        
        return baseObj;
    }
}
