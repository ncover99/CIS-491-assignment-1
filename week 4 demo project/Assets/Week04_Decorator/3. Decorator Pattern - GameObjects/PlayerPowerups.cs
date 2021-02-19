using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{
    //Notice this class does not extend MonoBehaviour
    [System.Serializable]
    public class PlayerPowerups  
    {
        [field: SerializeField] public virtual float speed { set; get; } = 5f;
        [field: SerializeField] public virtual string powerups { set; get; } = "";
    }
}