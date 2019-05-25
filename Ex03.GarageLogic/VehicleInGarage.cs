using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //NT DONE
    public class VehicleInGarage
    {
        public enum eVehicleStatus { InRepair, Repaired, Paid }

        const string k_VehicleInGarageDetails = "Owner Name: {0}\nOwner Phone: {1}\nVehicle Status: {2}\n{3}\n";
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;

        //*Properties*//

        public eVehicleStatus VehicleStatus
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        //*ctor*//
        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
        }


        //*Methods*//
        public void FillEnergy(int i_FuelType, float i_EnergyToAdd)
        {
            m_Vehicle.FillEnergy(i_FuelType, i_EnergyToAdd);
        }

        public void InflatingWheelsToMax()
        {
            m_Vehicle.inflatingWheelsToMax();
        }

        public override string ToString()
        { 
            return String.Format(k_VehicleInGarageDetails, m_OwnerName, m_PhoneNumber, m_VehicleStatus, m_Vehicle);
        }


     }
}