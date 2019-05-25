﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            Blue,
            Black,
            Gray
        }

        public enum eNumDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 31f;
        private eColor m_CarColor;
        private eNumDoors m_NumOfDoors;

        /*Properties*/
        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }
        public eNumDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
        }

        //*ctor*//
        public Car(eFuelType i_EngineType, float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
        {

        }

        public override Dictionary<string, string> GetListOfAdditionalFields()
        {
            return new Dictionary<string, string>
                  {
            { "CarColor", "Car Color, \n 0. Red\n 1. Blue\n 2. Black\n 3. Grey" },
            { "NumOfDoors", "Num of Doors, \n 0. Two\n 1. Three\n 2. Four\n 3. Five" }
                 };
        }

        //*Methods*//
        public override string ToString()
        {
            string data = String.Format("Color:{0},  Number of doors: {1} ", m_CarColor, m_NumOfDoors);
            return base.ToString() + data;
        }

        public override void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet)
        {
            if (Int32.TryParse(i_AdditionalFieldsToSet["CarColor"], out int carColorChoosed) && Enum.IsDefined(typeof(eColor), carColorChoosed))
            {
                m_CarColor = (eColor)carColorChoosed;
            }
            else
            {
                throw new FormatException("Car Color");
            }

            if (Int32.TryParse(i_AdditionalFieldsToSet["NumOfDoors"], out int numOfDoorsChoosed) && Enum.IsDefined(typeof(eNumDoors), numOfDoorsChoosed))
            {
                m_NumOfDoors = (eNumDoors)numOfDoorsChoosed;
            }
            else
            {
                throw new FormatException("Num Of Doors");
            }
        }
    }
}
