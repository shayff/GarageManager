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
        public Truck(eEngineType i_EnergySource, string i_NameOfModel, string i_LicenseNumber) :base(i_EnergySource, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, k_MaxAirPressure)
        {
        }
    }
}