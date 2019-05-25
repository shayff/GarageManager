using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicenseType { A, A1, A2, B }

    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 33f;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;// not use


        //*ctor*//
        public MotorCycle(eFuelType i_EngineType, float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {
        }

        public override Dictionary<string, string> GetListOfAdditionalFields()
        {
            return new Dictionary<string, string> { { "LicenseType", "license Type, \n 0. A\n 1. A1\n 2. A2\n 3. B" },
                { "EngineCapacity" ,"Engine Capacity (Enter an integer)"} };

        }

        //*Methods*//
        public override void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet)
        {
            if (Int32.TryParse(i_AdditionalFieldsToSet["LicenseType"], out int licenseTypeChoosed) && Enum.IsDefined(typeof(eLicenseType), licenseTypeChoosed))
            {
                m_LicenseType = (eLicenseType)licenseTypeChoosed;
            }
            else
            {
                throw new FormatException("LicenseType");
            }

            if (Int32.TryParse(i_AdditionalFieldsToSet["EngineCapacity"], out int EngineCapacity))
            {
                m_EngineCapacity = EngineCapacity;
                }
            else
            {
                throw new FormatException("EngineCapacity");
            }
        }


        public override string ToString()
        {
            string data = String.Format("License type: {0}\nEngine capacity: {1}\n ", m_LicenseType, m_EngineCapacity);
            return base.ToString() + data;
        }
    }
}