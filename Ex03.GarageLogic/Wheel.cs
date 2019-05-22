using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        const string k_TooMuchAirError = "Too much Air to add";
        private string m_NameOfYAZRAN;
        private readonly float r_MaxAirPressureLevel;
        private float m_AirPressureLevel;

        //*ctor*//
        public Wheel(string i_NameOfYAZRAN, float i_MaxAirPressureLevel, float i_PSILevel)
        {
            m_NameOfYAZRAN = i_NameOfYAZRAN;
            r_MaxAirPressureLevel = i_MaxAirPressureLevel;
            m_AirPressureLevel = i_PSILevel;
        }

        //*Methods*//
        public void InflatingWheelToMax()
        {
            m_AirPressureLevel = r_MaxAirPressureLevel;
        }

        public void InflatingWheel(float i_AirToAdd)
        {
            if (i_AirToAdd + m_AirPressureLevel <= r_MaxAirPressureLevel)
            {
                m_AirPressureLevel += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureLevel, k_TooMuchAirError);
            }
        }
    
    }
}