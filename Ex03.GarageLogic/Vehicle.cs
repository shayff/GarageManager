﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        enum eVehicleStatus { InRepair, Repaired, Paid }
        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyLevel;
        private Wheel[] m_Wheels;

        private Engine m_EnergySource;

        public Vehicle(int i_NumOfWheels,float i_PSILevel,eEngineType i_EnergySource)
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