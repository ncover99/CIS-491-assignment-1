/*
 * Nathan Cover
 * WeaponGenerator.cs
 * Assignment_04
 * Class that generates weapons of random type and then wraps it in a random rarity type before displaying it to the screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_03
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Text _weaponText;
        public Weapons Weapon;

        public void GenerateWeapon()
        {
            int weaponType = Random.Range(0, 3);
            switch (weaponType)
            {
                case 0:
                    this.Weapon = new WeaponSword();
                    break;
                case 1:
                    this.Weapon = new WeaponBow();
                    break;
                case 2:
                    this.Weapon = new WeaponClub();
                    break;
            }
            int RarityType = Random.Range(0, 100);
            if(RarityType <= 50)
                this.Weapon = new ModifierCommon(Weapon);
            else if (RarityType <= 80)
                this.Weapon = new ModifierRare(Weapon);
            else
                this.Weapon = new ModifierLegendary(Weapon);
            
            DisplayWeapon();
        }

        public void DisplayWeapon()
        {
            _weaponText.text = Weapon.ToString();
        }
    }
}