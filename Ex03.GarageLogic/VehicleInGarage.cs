using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //NT DONE
    public class VehicleInGarage
    {
        public enum eVehicleStatus { InRepair, Repaired, Paid }

        const string k_VehicleInGarageDetails = "Owner Name:{0}, Owner Phone: {1},Vehicle Status: {2}, {3} ";
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;

        /*Properties*/
        public eVehicleStatus VehicleStatus
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }
        
        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
        }

        public void FillEnergy(eFuelType i_FuelType ,float i_EnergyToAdd)
        {
            FillEnergy(i_FuelType, i_EnergyToAdd);
        }

        public void InflatingWheelsToMax()
        {
            InflatingWheelsToMax();
        }

        public override string ToString()
        { 
            return String.Format(k_VehicleInGarageDetails, m_OwnerName, m_PhoneNumber, m_VehicleStatus, m_Vehicle);
        }


     }
}