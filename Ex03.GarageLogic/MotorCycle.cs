using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private enum eLicenseType
        {
            A, A1, A2, B
        }

        private const string k_NoSuchAOption = "There isn't such option for ";
        private const string k_InvalidValue = "Invalid value";

        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 33f;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public MotorCycle(Engine.eFuelType i_EngineType, float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {
        }

        public override Dictionary<string, string> GetListOfAdditionalFields()
        {
            return new Dictionary<string, string>
            {
                { "LicenseType", "license Type, \n 0. A\n 1. A1\n 2. A2\n 3. B" },
                { "EngineCapacity" , "Engine Capacity (Enter an integer)" }
            };
        }

        public override void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet)
        {
            if (int.TryParse(i_AdditionalFieldsToSet["LicenseType"], out int licenseTypeChoosed))
            {
                if (Enum.IsDefined(typeof(eLicenseType), licenseTypeChoosed))
                {
                    m_LicenseType = (eLicenseType)licenseTypeChoosed;
                }
                else
                {
                    throw new ArgumentException(k_NoSuchAOption + "LicenseType");
                }
            }
            else
            {
                throw new FormatException("LicenseType Error" + k_InvalidValue);
            }

            if (int.TryParse(i_AdditionalFieldsToSet["EngineCapacity"], out int EngineCapacity))
            {
                if (EngineCapacity >= 0)
                {
                    m_EngineCapacity = EngineCapacity;
                }
                else
                {
                    throw new ArgumentException("The value must be at least 0");
                }
            }
            else
            {
                throw new FormatException("LicenseType: The value is invalid, please try again");
            }
        }

        public override string ToString()
        {
            string data = string.Format("License type: {0}\nEngine capacity: {1}\n ", m_LicenseType, m_EngineCapacity);
            return base.ToString() + data;
        }
    }
}