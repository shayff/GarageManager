using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_NameOfYAZRAN;
        private float m_MaxPsiLevel;
        private float m_PSILevel;

        //*ctor*//
        public Wheel(string i_NameOfYAZRAN, float i_MaxPsiLevel, float i_PSILevel)
        {
            m_NameOfYAZRAN = i_NameOfYAZRAN;
            m_MaxPsiLevel = i_MaxPsiLevel;
            m_PSILevel = i_PSILevel;
        }

        //*Methods*//
        public void InflatingWheelToMax()
        {
            m_PSILevel = m_MaxPsiLevel;
        }

        public void InflatingWheel(float i_AirToAdd)
        {
            if (i_AirToAdd + m_PSILevel <= m_MaxPsiLevel)
            {
                m_PSILevel += i_AirToAdd;
            }
            else
            {
                //Exceptions
            }
        }
    
    }
}