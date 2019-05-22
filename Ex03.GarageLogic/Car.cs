using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 31f;

        public enum eColor {Red,Blue,Black,Gray};
        public enum eNumOfDoors { Two,Three,Four,Five };

        eColor m_CarColor;
        int m_NumOfDoors;
        //, eColor i_CarColor,int i_NumOfDoors
        public Car(eEngineType i_EnergySource) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {}
    }
}