/*
 * Nathan Cover
 * WeaponSword.cs
 * Assignment_04
 * Base class for sword weapons that contain base stats and attributes of a sword
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class WeaponSword : Weapons
    {
        public WeaponSword()
        {
            this.Name = "Sword";
        }
        public override Stats GetStats()
        {
            Stats output = new Stats();
            output.Damage = 10;
            output.DamageType = DamageType.Cut;
            output.Value = 74;
            return output;
        }
    }
}