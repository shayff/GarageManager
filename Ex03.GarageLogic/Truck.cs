using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 26f;
        private bool m_IsDriveDangerousCargo;
        private float m_CargoCapacity;

        //*Properties*//
        public bool IsDriveDangerousCargo
        {
            set { m_IsDriveDangerousCargo = value; }
            get { return m_IsDriveDangerousCargo; }
        }

        public float CargoCapacity
        {
            set { m_CargoCapacity = value; }
            get { return m_CargoCapacity; }
        }

        //*ctor**/
        // bool i_IsDriveDangerousCargo, float i_CargoCapacity
        public Truck(eFuelType i_EngineType, string i_NameOfModel, string i_LicenseNumber, string i_NameOfWheelManufacturer, float i_AirPressureLevel) : base(i_EngineType, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaxAirPressure, i_AirPressureLevel)
        {
            m_AdditionalFields =new string[]{ "IsDriveDangerousCargo", "CargoCapacity" };
        }

        public override void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet)
        {
            m_IsDriveDangerousCargo = i_AdditionalFieldsToSet["IsDriveDangerousCargo"] == 0;
            m_CargoCapacity = (float)i_AdditionalFieldsToSet["CargoCapacity"];
        }

    }
}