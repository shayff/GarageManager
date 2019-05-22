using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicneceType { A,A1,A2,B}
    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 33f;
        private eLicneceType m_LicneceType;
        private int m_EngineCapcity;


        //*Methods*//
        public MotorCycle(eEnergyType i_EnergySource, string i_NameOfModel, string i_LicenseNumber) :base(i_EnergySource, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, k_MaxAirPressure)
        {

        }
    }
}