/*
* Nathan Cover
* HeroCreator.cs
* assignment 6
* factory class to spawn Hero type npcs
*/
using UnityEngine;

public class HeroCreator : NPCCreator
{

    public override GameObject CreateNpc(GameObject baseObj)
    {
        baseObj.AddComponent<Cop>();
        
        return baseObj;
    }
}
