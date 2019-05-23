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
        private Wheel[] m_Wheels;
        private Engine m_Engine;
        public static string[] m_AdditonalFields;

        public T dosomething<T>(object o)
        {
            T enumVal = (T)Enum.Parse(typeof(T), o.ToString());
            return enumVal;
        }

        /*
         * object o = 4;
         *dosomething<Crustaceans>(o);
       = =/*

        //*Properties*/
        public string[] AdditonalFields
        {
            get { return m_AdditonalFields; }
        }

        public Engine EnergySource
        {
            set { m_Engine = value; }
            get { return m_Engine; }
        }

        public Wheel[] Wheels
        {
            set { m_Wheels = value; }
            get { return m_Wheels; }
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

        public Vehicle(eFuelType i_EngineType,float FuelCapacity, string i_NameOfModel, string i_LicenseNumber, int i_NumOfWheels, float i_MaxAirPressureLevel)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_NameOfModel = i_NameOfModel;

            m_Engine = new Engine(i_EngineType, FuelCapacity);

            m_Wheels = new Wheel[i_NumOfWheels] ;
            //init wheels
            //NT need to init wheels with the psi level

        }

        //*Methods*//
        public void ChangeStatus()
        {

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

        public abstract void SetAdditonalFields(Dictionary<string, int> i_AdditonalFieldsToSet);
    }
}