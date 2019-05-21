using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 26f;

        bool m_IsDriveDangerousCargo;
        float m_CargoCapacity;

        public Truck(eEngineType i_EnergySource, bool i_IsDriveDangerousCargo, float i_CargoCapacity) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {
           m_IsDriveDangerousCargo = i_IsDriveDangerousCargo;
           m_CargoCapacity = i_CargoCapacity;
        }
    }
}