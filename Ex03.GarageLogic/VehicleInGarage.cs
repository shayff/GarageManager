using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eVehicleStatus { InRepair, Repaired, Paid }

        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_OwnerName;
        private string m_PhoneNumber;
        public Vehicle m_Vehicle;

        /*Properties*/
        public eVehicleStatus VehicleStatus
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }

        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber)
        { }

        public string VehicleInGarageDetails()
        {
            return String.Format("Owner Name:{0}, Owner Phone: {1},Vehicle Status: {2}, {3} ", m_OwnerName, m_PhoneNumber, m_VehicleStatus, m_Vehicle.VehicleDetails());
     }
}