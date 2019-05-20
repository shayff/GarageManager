﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicneceType { A,A1,A2,B}
    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 33f;

        eLicneceType m_LicneceType;
        int m_EngineCapcity;

        public MotorCycle(eEngineType i_EnergySource) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {

        }
    }
}