using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor { Red, Blue, Black, Gray };

        public enum eNumDoors
        {
            Two,
            Three,
            Four,
            Five
        };

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
        public Car(eFuelType i_EngineType, string i_NameOfModel, string i_LicenseNumber) : base(i_EngineType, i_NameOfModel, i_LicenseNumber, k_NumberOfWheels, k_MaxAirPressure)
        {
            m_AdditionalFields = new Dictionary<string, string>
                  {
            { "CarColor", "Car Color, \n 0. Red\n 1. Blue\n 2. Black\n 3. Grey" },
            { "NumOfDoors", "Num of Doors, \n 0. Two\n 1. Three\n 2. Four\n 3. Five" }
                 };
        }
        //*Methods*//
        public override string VehicleDetails()
        {
            return String.Format("Color:{0},  Number of doors: {1} ", m_CarColor, m_NumOfDoors);
        }

        public override void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet)
        {
            m_CarColor = (eColor)i_AdditionalFieldsToSet["CarColor"];
            m_NumOfDoors = (eNumDoors)i_AdditionalFieldsToSet["NumOfDoors"];
        }
    }
}
