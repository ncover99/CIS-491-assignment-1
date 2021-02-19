/*
 * Nathan Cover
 * WeaponClub.cs
 * Assignment_04
 * Base class for club weapons that contain base stats and attributes of a club
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class WeaponClub : Weapons
    {
        public WeaponClub()
        {
            this.Name = "Club";
        }
        
        public override Stats GetStats()
        {
            Stats output = new Stats();
            output.Damage = 10;
            output.DamageType = DamageType.Blunt;
            output.Value = 180;
            return output;
        }
    }
}
