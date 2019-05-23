using System;
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
        public Car(eFuelType i_EngineType, string i_NameOfModel ,string i_LicenseNumber, string i_NameOfWheelManufacturer, float i_AirPressureLevel) :base(i_EngineType, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaxAirPressure, i_AirPressureLevel)
        {
            m_AdditionalFields = new string[] { "CarColor", "NumOfDoors" };
        }

        //*Methods*//
        public override string VehicleDetails()
        {
            return String.Format("Color:{0},  Number of doors: {1} ", m_CarColor, m_NumOfDoors);
        }

        public override void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet)
        {
            m_CarColor = (eColor)i_AdditionalFieldsToSet["CarColor"];
            m_NumOfDoors = (int)i_AdditionalFieldsToSet["NumOfDoors"];
        }
    }
}
 