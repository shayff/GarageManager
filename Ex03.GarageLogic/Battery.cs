using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        const string k_ErrorTooMuchEnergy = "You insert too much energy";
        private float m_BatteryTimeRemaining;
        private readonly float r_BatteryMaxCapacity;

        //*ctor*//
        public Battery(float i_BatteryMaxCapacity)
        {
            r_BatteryMaxCapacity = i_BatteryMaxCapacity;
        }

        //*Methods*//
        public override void FillEnergy(float i_HoursToAdd)
        {
            if (m_BatteryTimeRemaining + i_HoursToAdd <= r_BatteryMaxCapacity)
            {
                m_BatteryTimeRemaining += i_HoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_BatteryMaxCapacity, k_ErrorTooMuchEnergy);
            }
        }
        public override eEnergyType GetEnergyType()
        {
            return eEnergyType.Electricity;
        }
    }
}