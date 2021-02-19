using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{
    public abstract class PlayerDecorator : PlayerPowerups
    {
        public override abstract float speed {get; set;}
        public override abstract string powerups { get; set; }

    }
}