﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : Engine
    {
        private float m_BatteryTimeRemaining;
        private readonly float m_BatteryMaxCapacity;

        public Battery(float i_BatteryMaxCapacity)
        {
            m_BatteryMaxCapacity = i_BatteryMaxCapacity;
        }

        public override void FillEnergy(float i_HoursToAdd)
        {
            if (m_BatteryTimeRemaining + i_HoursToAdd <= m_BatteryMaxCapacity)
            {
                m_BatteryTimeRemaining += i_HoursToAdd;
            }
            else
            {
                //Exceptions

            }
        }
    }
}