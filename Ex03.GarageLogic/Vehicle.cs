using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyLevel;
        private Engine m_Engine;
        private List<Wheel> m_Wheels;
        private int r_NumberOfWheels;
        private readonly float r_MaxAirPressureLevel;

        public int NumberOfWheels
        {
            get { return r_NumberOfWheels; }
        }
        
        //*Properties*/
        public Engine EnergySource
        {
            set { m_Engine = value; }
            get { return m_Engine; }
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

        public float EnergyLevel
        {
            set { m_EnergyLevel = value; }
            get { return m_EnergyLevel; }
        }


        //*ctor*//
        public Vehicle(string i_LicenseNumber)
        {
            string m_LicenseNumber = i_LicenseNumber;
        }

        public Vehicle(eFuelType i_EngineType, float i_MaxEnergyCapacity, int i_NumOfWheels, float i_MaxAirPressureLevel)
        {
            m_Engine = new Engine(i_EngineType, i_MaxEnergyCapacity);
            r_NumberOfWheels = i_NumOfWheels;
            r_MaxAirPressureLevel = i_MaxAirPressureLevel;
        }
        
        public void InitWheels(float i_AirPressureLevel,string i_NameOfWheelManuFacturer)
        {
            List<Wheel> m_Wheels = new List<Wheel>();
            for (int i = 0; i < r_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(r_MaxAirPressureLevel,i_NameOfWheelManuFacturer,i_AirPressureLevel));
            }
        }
        
        public void FillEnergy(eFuelType i_FuelType, float i_FuelToAdd)
        {
            m_Engine.FillEnergy(i_FuelType, i_FuelToAdd);
        }

        public void InflatingWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflatingWheelToMax();
            }
        }

        //NT need that?
        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            string vehicleDetailsString = string.Format("License Number: {0}, Model Name: {1}", m_LicenseNumber, m_NameOfModel);
            vehicleDetailsString += m_Engine;
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleDetailsString += wheel.WheelDetails();
            }
            return vehicleDetailsString;
        }

        public abstract Dictionary<string, string> GetListOfAdditionalFields();

        public abstract void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet);


        //NT need that?
        public void AddDetailsWheels(string i_NameOfWheelManufacturer, float i_AirPressureLevel)
        {
            foreach (Wheel wheels in m_Wheels)
            {
                wheels.AirPressureLevel = i_AirPressureLevel;
                wheels.NameOfManufacturer = i_NameOfWheelManufacturer;
            }

        }
        
    }
}