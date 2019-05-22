using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        float m_MinValue;
        float m_MaxValue;

        public float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }
        
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ErrorMessage):base(i_ErrorMessage)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}

    
}