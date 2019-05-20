using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        private float m_BatteryTimeRemaining;
        private float m_BatteryMaxCapacity;

        public Battery(float i_BatteryMaxCapacity)
        {
            m_BatteryMaxCapacity = i_BatteryMaxCapacity;
        }

        public override void FillEnergy(float i_HoursToAdd)
        {

        }
    }
}