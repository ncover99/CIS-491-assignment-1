/*
 * Nathan Cover
 * WeaponDecorator.cs
 * Assignment_04
 * Parent Class for weapon modifier wrappers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assignment_03
{
    public abstract class WeaponDecorator : Weapons
    {
        public override abstract string GetName();
    }
}