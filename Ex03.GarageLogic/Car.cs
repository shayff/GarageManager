using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red, Blue, Black, Gray
        }

        public enum eNumDoors
        {
            Two, Three, Four, Five
        }

        private const string k_NoSuchAOption = "There isn't such option for ";
        private const string k_InvalidValue = "Invalid value";

        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 31f;
        private eColor m_CarColor;
        private eNumDoors m_NumOfDoors;

        public Car(Engine.eFuelType i_EngineType, float i_MaxEnergyCapacity) : base(i_EngineType, i_MaxEnergyCapacity, k_NumberOfWheels, k_MaxAirPressure)
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

        public override string ToString()
        {
            string data = string.Format("Color: {0}\nNumber of doors: {1}\n", m_CarColor, m_NumOfDoors);
            return base.ToString() + data;
        }

        public override void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet)
        {
            if (int.TryParse(i_AdditionalFieldsToSet["CarColor"], out int carColorChoice))
            {
                if (Enum.IsDefined(typeof(eColor), carColorChoice))
                {
                    m_CarColor = (eColor)carColorChoice;
                }
                else
                {
                    throw new ArgumentException(k_NoSuchAOption + "color");
                }
            }
            else
            {
                throw new FormatException("Car Color Error:" + k_InvalidValue);
            }

            if (int.TryParse(i_AdditionalFieldsToSet["NumOfDoors"], out int numOfDoorsChoice))
            {
                if (Enum.IsDefined(typeof(eNumDoors), numOfDoorsChoice))
                {
                    m_NumOfDoors = (eNumDoors)numOfDoorsChoice;
                }
                else
                {
                    throw new ArgumentException(k_NoSuchAOption + "Num Of Doors");
                }
            }
            else
            {
                throw new FormatException("Num Of Doors Error:" + k_InvalidValue);
            }
        }
    }
}
