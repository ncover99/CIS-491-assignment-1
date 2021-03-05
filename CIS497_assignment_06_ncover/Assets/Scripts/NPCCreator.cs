/*
* Nathan Cover
* NPCCreator.cs
* assignment 6
* interface/ abstract class for other npc factories
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCCreator
{
    public abstract GameObject CreateNpc(GameObject baseObj);
}
