using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Week04_Decorator._3._Decorator_Pattern___GameObjects
{
    public class PowerupSpeedDownLarge : PlayerDecorator
    {
        public PlayerPowerups playerPowerups;

        public PowerupSpeedDownLarge(PlayerPowerups playerPowerups)
        {
            this.playerPowerups = playerPowerups;
        }


        public override float speed
        {
            get
            {
                return playerPowerups.speed - 5;
            }
            set
            {
                playerPowerups.speed = value;
            }

        }
        public override string powerups
        {
            get
            {
                return playerPowerups.powerups += ", SpeedDownLarge";
            }
            set
            {
                playerPowerups.powerups = value;
            }
        }


    }
}