using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        private float m_BatteryTimeRemaining;
        private readonly float m_BatteryMaxCapacity;

        //*ctor*//
        public Battery(float i_BatteryMaxCapacity)
        {
            m_BatteryMaxCapacity = i_BatteryMaxCapacity;
        }

        //*Methods*//
        public override void FillEnergy(float i_HoursToAdd)
        {
            if (m_BatteryTimeRemaining + i_HoursToAdd <= m_BatteryMaxCapacity)
            {
                m_BatteryTimeRemaining += i_HoursToAdd;
            }
            else
            {
   

            }
        }
    }
}