/*
* Nathan Cover
* EnemyCreator.cs
* assignment 6
* factory class to spawn Enemy type npcs
*/

using UnityEngine;

public class EnemyCreator : NPCCreator
{

    public override GameObject CreateNpc(GameObject baseObj)
    {
        baseObj.AddComponent<Criminal>();
        
        return baseObj;
    }
}
