﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const string k_ErrorTooMuchAir = "Too much Air to add";
        private const string k_ErrorNotPositiveNumber = "The number is not positive";
        private const string k_ErrorValueOutOfRange = "The values are out of range";
        private const string k_WheelDetails = "Manufacturer: {0}, AirPressure Level: {1}\n";
        private readonly float r_MaxAirPressureLevel;
        private readonly string r_NameOfManufacturer;
        private float m_AirPressureLevel;

        public float MaxAirPressureLevel
        {
            get { return r_MaxAirPressureLevel; }
        }

        public float AirPressureLevel
        {
            get { return m_AirPressureLevel; }
        }

        public Wheel(float i_MaxAirPressureLevel, string i_NameOfManufacturer, float i_CurrentAirPressureLevel)
        {
            r_NameOfManufacturer = i_NameOfManufacturer;
            r_MaxAirPressureLevel = i_MaxAirPressureLevel;
            bool validAirPressure = i_CurrentAirPressureLevel >= 0 && i_CurrentAirPressureLevel <= r_MaxAirPressureLevel;
            if (validAirPressure)
            {
                m_AirPressureLevel = i_CurrentAirPressureLevel;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureLevel, "k_ErrorValueOutOfRange");
            }
        }

        public void InflatingWheelToMax()
        {
            m_AirPressureLevel = r_MaxAirPressureLevel;
        }

        public void InflatingWheel(float i_AirToAdd)
        {
            bool validAirToAdd = i_AirToAdd + m_AirPressureLevel <= r_MaxAirPressureLevel;
            if (validAirToAdd)
            {
                m_AirPressureLevel += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureLevel, k_ErrorValueOutOfRange);
            }
        }

        public override string ToString()
        {
            return string.Format(k_WheelDetails, r_NameOfManufacturer, m_AirPressureLevel);
        }
    }
}