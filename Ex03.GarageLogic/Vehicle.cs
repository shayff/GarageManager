using System;
using System.Collections.Generic;
using System.Text;
//NT done
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        const string k_VehicleDetails = "License Number: {0}\nModel Name: {1}\n";

        private string m_NameOfModel;
        private string m_LicenseNumber;

        private Engine m_Engine;
        private List<Wheel> m_Wheels;
        private int r_NumberOfWheels;
        private readonly float r_MaxAirPressureLevel;

        public Engine Engine
        {
            get { return m_Engine; }
        }
        public int NumberOfWheels
        {
            get { return r_NumberOfWheels; }
        }

        public float MaxAirPressureLevel
        {
            get { return r_MaxAirPressureLevel; }
        }

        public string LicenseNumber
        {
            set { m_LicenseNumber = value; }
            get { return m_LicenseNumber; }
        }

        public string NameOfModel
        {
            set { m_NameOfModel = value; }
            get { return m_NameOfModel; }
        }

        public abstract Dictionary<string, string> GetListOfAdditionalFields();
        public abstract void SetAdditionalFields(Dictionary<string, string> i_AdditionalFieldsToSet);

        //*ctor*//
        public Vehicle(eFuelType i_EngineType, float i_MaxEnergyCapacity, int i_NumOfWheels, float i_MaxAirPressureLevel)
        {
            m_Engine = new Engine(i_EngineType, i_MaxEnergyCapacity);
            r_NumberOfWheels = i_NumOfWheels;
            r_MaxAirPressureLevel = i_MaxAirPressureLevel;
        }
        
        public void InitWheels(float i_AirPressureLevel,string i_NameOfWheelManuFacturer)
        {
            m_Wheels = new List<Wheel>();
            for (int i = 0; i < r_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(r_MaxAirPressureLevel,i_NameOfWheelManuFacturer,i_AirPressureLevel));
            }
        }
        
        public void FillEnergy(eFuelType i_FuelType, float i_FuelToAdd)
        {
            m_Engine.FillEnergy(i_FuelType, i_FuelToAdd);
        }

        private void inflatingWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflatingWheelToMax();
            }
        }

        public override string ToString()
        {
            string[] number = { "Wheels: \n1.", "2.", "3.", "4."};
            int index = 0;
            string vehicleDetailsString = string.Format(k_VehicleDetails, m_LicenseNumber, m_NameOfModel);
            vehicleDetailsString += m_Engine;
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleDetailsString += number[index++] + wheel;
            }
            return vehicleDetailsString;
        }

    }
}