﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor { Red, Blue, Black, Gray };

        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 31f;
        private eColor m_CarColor;
        private int m_NumOfDoors;

        /*Properties*/
        public eColor CarColor
        {
            set { m_CarColor = value; }
            get { return m_CarColor;
            }
        }
        public  int NumOfDoors
        {
            set { m_NumOfDoors = value; }
            get { return m_NumOfDoors; }
        }

        //*ctor*//
        //eColor i_CarColor,int i_NumOfDoors, 
        public Car(eEngineType i_EnergySource) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {

        }
    }
}