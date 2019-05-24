using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        const string k_ErrorTooMuchAir = "Too much Air to add";
        const string k_ErrorNotPositiveNumber = "The number is not positive";
        private string m_NameOfManufacturer;
        private readonly float r_MaxAirPressureLevel;
        private float m_AirPressureLevel;


        //*Properties*/
        public float MaxAirPressureLevel
        {
            get { return r_MaxAirPressureLevel; }
        }

        public float AirPressureLevel
        {
            get { return m_AirPressureLevel; }
            set { m_AirPressureLevel = value; }
        }

        public string NameOfManufacturer
        {
            get { return m_NameOfManufacturer; }
            set { m_NameOfManufacturer = value; }
        }

        //*ctor*//
        public Wheel(float i_MaxAirPressureLevel, string i_NameOfManufacturer, float i_CurrentAirPressureLevel)
        {
            m_NameOfManufacturer = i_NameOfManufacturer;
            r_MaxAirPressureLevel = i_MaxAirPressureLevel;
            if (i_CurrentAirPressureLevel >= 0 && i_CurrentAirPressureLevel <= r_MaxAirPressureLevel)
            {
                m_AirPressureLevel = i_CurrentAirPressureLevel;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureLevel, "error"); //NT error message
            }
        }


        //*Methods*//
        public void InflatingWheelToMax()
        {
            m_AirPressureLevel = r_MaxAirPressureLevel;
        }

        public void InflatingWheel(float i_AirToAdd)
        {
            if ((i_AirToAdd + m_AirPressureLevel <= r_MaxAirPressureLevel) && (i_AirToAdd >= 0))
            {
                m_AirPressureLevel += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureLevel, k_ErrorTooMuchAir);
            }
        }

        public string WheelDetails()
        {
            return String.Format("Manufacturer: {0}, AirPressure Level: {1}", m_NameOfManufacturer, m_AirPressureLevel);
        }

    }
}