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
        private List<Wheel> m_Wheels;
        private Engine m_Engine;
        // public static string[] m_AdditionalFields;
        public static Dictionary<string, string> m_AdditionalFields;

        /*
        public T dosomething<T>(object o)
        {
            T enumVal = (T)Enum.Parse(typeof(T), o.ToString());
            return enumVal;
        }*/

        /*
         * object o = 4;
         *do something<Crustaceans>(o);
       /*

        //*Properties*/
        public Dictionary<string, string> AdditionalFields
        {
            get { return m_AdditionalFields; }
        }

        public Engine EnergySource
        {
            set { m_Engine = value; }
            get { return m_Engine; }
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

        public Vehicle(eFuelType i_EngineType, string i_NameOfModel, string i_LicenseNumber, int i_NumOfWheels, float i_MaxAirPressureLevel)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_NameOfModel = i_NameOfModel;

            m_Engine = new Engine(i_EngineType); //FuelCapacity);
            m_Wheels = CreateWheels(i_NumOfWheels, i_MaxAirPressureLevel);
        }

        public List<Wheel> CreateWheels(int i_NumOfWheels, float i_MaxAirPressureLevel)
        {
            List<Wheel> Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressureLevel));
            }
            return Wheels;
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

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public virtual string VehicleDetails()
        {
            string vehicleDetailsString = string.Format("License Number: {0}, Model Name: {1}", m_LicenseNumber, m_NameOfModel);
            vehicleDetailsString += m_Engine.EngineDetails();
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleDetailsString += wheel.WheelDetails();
            }
            return vehicleDetailsString;
        }

        public abstract void SetAdditionalFields(Dictionary<string, int> i_AdditionalFieldsToSet);

        public void AddDetailsWheels(string i_NameOfWheelManufacturer, float i_AirPressureLevel)
        {
            foreach (Wheel wheels in m_Wheels)
            {
                wheels.AirPressureLevel = i_AirPressureLevel;
                wheels.NameOfManufacturer = i_NameOfWheelManufacturer;
            }
        }

        public float GetMaxAirPressureLevel()
        {
            return m_Wheels[0].MaxAirPressureLevel;
        }
    }
}