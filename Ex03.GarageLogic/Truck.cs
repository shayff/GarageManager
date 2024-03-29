﻿using System;
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

        public bool IsDriveDangerousCargo
        {
            get { return m_IsDriveDangerousCargo; }
            set { m_IsDriveDangerousCargo = value; }
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
            set { m_CargoCapacity = value; }
        }

        public Truck(Engine.eFuelType i_EngineType, float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {
        }

        public override Dictionary<string, string> GetListOfAdditionalFields()
        {
            return new Dictionary<string, string> { { "IsDriveDangerousCargo", "Is Drive Dangerous Cargo Type, \n 0. YES\n 1. NO" }, { "CargoCapacity", "Cargo Capacity Insert in float" } };
        }

        public override void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet)
        {
            if (int.TryParse(i_AdditionalFieldsToSet["IsDriveDangerousCargo"], out int isDriveDangerCargo))
            {
                if (isDriveDangerCargo == 0)
                {
                    m_IsDriveDangerousCargo = true;
                }
                else if (isDriveDangerCargo == 1)
                {
                    m_IsDriveDangerousCargo = false;
                }
                else
                {
                    throw new FormatException("IsDriveDangerousCargo");
                }
            }
            else
            {
                throw new FormatException("IsDriveDangerousCargo");
            }

            if (float.TryParse(i_AdditionalFieldsToSet["CargoCapacity"], out float CargoCapacity))
            {
                if (CargoCapacity > 0)
                {
                    m_CargoCapacity = CargoCapacity;
                }
                else
                {
                    throw new ArgumentException("The value must be at least 0");
                }
            }
            else
            {
                throw new FormatException("CargoCapacity: The value is invalid, please try again");
            }
        }

        public override string ToString()
        {
            string data = string.Format("Is drive dangerous cargo: {0}\nCargo capacity: {1}\n ", m_IsDriveDangerousCargo, m_CargoCapacity);

            return base.ToString() + data;
        }
    }
}