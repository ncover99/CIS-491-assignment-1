/*
 * Nathan Cover
 * ModifierLegendary.cs
 * Assignment_04
 * Wrapper class to specify a rarity type for a randomly generated weapon and adjusts
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public class ModifierLegendary : WeaponDecorator
    {
        private Weapons _weapons;

        public ModifierLegendary(Weapons weapons)
        {
            this._weapons = weapons;
        }

        public override string GetName()
        {
            return "Legendary" + " " + _weapons.GetName();
        }

        public override Stats GetStats()
        {
            var output = new Stats
            {
                DamageType = _weapons.GetStats().DamageType,
                Damage = _weapons.GetStats().Damage + 10,
                Value = _weapons.GetStats().Value * 3
            };
            return output;
        }
    }
}