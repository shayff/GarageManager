using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicneceType { A, A1, A2, B }
    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 33f;
        private eLicneceType m_LicneceType;
        private int m_EngineCapcity;


        //*ctor*//
        public MotorCycle(eFuelType i_EngineType,float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {
            m_AdditionalFields = new Dictionary<string, string> { { "LicneceType", "license Type, \n 0. A\n 1. A1\n 2. A2\n 3. B" },
                { "EngineCapcity" ,"bla"} };


        }

        //*Methods*//
        public override void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet)
        {
            if (i_AdditionalFieldsToSet.ContainsKey("LicneceType"))
            {
                m_LicneceType = (eLicneceType)i_AdditionalFieldsToSet["LicneceType"];
            }

            m_EngineCapcity = (int)i_AdditionalFieldsToSet["EngineCapcity"];
        }
    }
}