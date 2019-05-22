using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private VehicleInGarage m_VehicleTicket;
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyLevel;
        private Wheel[] m_Wheels;
        private EnergySource m_EnergySource;


        //*Properties*//
        public EnergySource EnergySource
        {
            set { m_EnergySource=value; }
            get { return m_EnergySource; }
        }
        public Wheel[] Wheels
        {
            set { m_Wheels = value; }
            get { return m_Wheels; }
        }
        public VehicleInGarage VehicleTicket
        {
            set { m_VehicleTicket = value; }
            get { return m_VehicleTicket; }

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
        public Vehicle(eEngineType i_EnergySource, string i_NameOfModel, string i_LicenseNumber, int i_NumOfWheels, float i_PSILevel)
        {
            string m_NameOfModel = i_NameOfModel;
            string m_LicenseNumber = i_LicenseNumber;

           m_Wheels = new Wheel[i_NumOfWheels];
            //NT need to init wheels with the psi level
            if(i_EnergySource == eEngineType.Fuel)
            {
                //m_EnergySource = new FuelTank();
            }
            else if (i_EnergySource == eEngineType.Fuel)
            {
                //m_EnergySource = new Battery();
            }

               
        }


        //*Methods*//
        public void ChangeStatus()
        {

        }
        public void FillEnergy()
        {

        }
        public void ShowVehicleDetails()
        {

        }
    }
}