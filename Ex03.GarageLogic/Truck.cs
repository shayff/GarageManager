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

        //, bool i_IsDriveDangerousCargo, float i_CargoCapacity
        public Truck(eEngineType i_EnergySource) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {
        }
    }
}