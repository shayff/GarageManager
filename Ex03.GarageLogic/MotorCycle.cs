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
        public MotorCycle(eFuelType i_EngineType, string i_NameOfModel, string i_LicenseNumber, string i_NameOfWheelManufacturer, float i_AirPressureLevel) : base(i_EngineType, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaxAirPressure, i_AirPressureLevel)
        {
            m_AdditonalFields = new string[] { "LicneceType", "EngineCapcity" };
        }

        //*Methods*//
        public override void SetAdditonalFields(Dictionary<string, int> i_AdditonalFieldsToSet)
        {
            if (i_AdditonalFieldsToSet.ContainsKey("LicneceType"))
            {
                m_LicneceType = (eLicneceType)i_AdditonalFieldsToSet["LicneceType"];
            }

            m_EngineCapcity = (int)i_AdditonalFieldsToSet["EngineCapcity"];
        }
    }
}