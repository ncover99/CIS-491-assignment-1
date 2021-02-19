/*
 * Nathan Cover
 * WeaponBow.cs
 * Assignment_04
 * Base class for bow weapons that contain base stats and attributes of a bow
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class WeaponBow : Weapons
    {
        public WeaponBow()
        {
            this.Name = "Bow";
        }
        
        public override Stats GetStats()
        {
            Stats output = new Stats();
            output.Damage = 5;
            output.DamageType = DamageType.Pierce;
            output.Value = 150;
            return output;
        }
    }
}