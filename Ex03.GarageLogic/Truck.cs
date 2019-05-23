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
        public Truck(eFuelType i_EngineType,float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {
            m_AdditionalFields =new Dictionary<string,string>{ {"IsDriveDangerousCargo", "Is Drive Dangerous Cargo Type, \n 0. YES\n 1. NO" },
                { "CargoCapacity", "Cargo Capacity Insert in float" } };
        }

        public override void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet)
        {
            m_IsDriveDangerousCargo = i_AdditionalFieldsToSet["IsDriveDangerousCargo"] == 0;
            m_CargoCapacity = (float)i_AdditionalFieldsToSet["CargoCapacity"];
        }

    }
}