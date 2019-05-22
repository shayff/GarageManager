using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private VehicleTicket m_VehicleTicket;
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyLevel;
        private Wheel[] m_Wheels;

        private EnergySource m_EnergySource;


        //*Properties*//
        public Wheel[] Wheels
        {
            set { ;}
            get { return m_Wheels; }
        }
        public VehicleTicket VehicleTicket
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


        public Vehicle(int i_NumOfWheels, float i_PSILevel, eEngineType i_EnergySource)
        {
            m_Wheels = new Wheel[i_NumOfWheels];
            //NT need to init wheels with the psi level

        }
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