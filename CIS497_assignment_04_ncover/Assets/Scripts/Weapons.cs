/*
 * Nathan Cover
 * Weapons.cs
 * Assignment_04
 * Parent Class for weapons and weapon modifier wrappers, holds base variables for determining the name, description, and damage type of a weapon
 */

using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Assignment_03;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public abstract class Weapons
    {
        public enum DamageType {Cut, Pierce, Blunt }
        
        public struct Stats
        {
            public int Damage;
            public DamageType DamageType;
            public int Value;
        }
        
        public string Name = "Weapon";

        public virtual string GetName()
        {
            return Name;
        }

        public abstract Stats GetStats();

        public string ToString()
        {
            var output = this.GetName() + "\n" +
                        "Damage: " + GetStats().Damage.ToString() + "\n" + 
                        "Value: " + GetStats().Value.ToString() + "\n" +
                        "Damage Type: " + GetStats().DamageType.ToString();

            return output;
        }
    }
}