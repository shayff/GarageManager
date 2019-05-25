using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eVehicleStatus { InRepair, Repaired, Paid }

        const string k_VehicleInGarageDetails = "Owner Name: {0}\nOwner Phone: {1}\nVehicle Status: {2}\n{3}\n";
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;


        public eVehicleStatus VehicleStatus
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
        }

        public void FillEnergy(int i_FuelType, float i_EnergyToAdd)
        {
            m_Vehicle.FillEnergy(i_FuelType, i_EnergyToAdd);
        }

        public void InflatingWheelsToMax()
        {
            m_Vehicle.InflatingWheelsToMax();
        }

        public override string ToString()
        {
            return string.Format(k_VehicleInGarageDetails, m_OwnerName, m_PhoneNumber, m_VehicleStatus, m_Vehicle);
        }

        public void SetVehicleStatusFromInt(int i_NewStatus)
        {
            if (Enum.IsDefined(typeof(eVehicleStatus), i_NewStatus))
            {
                m_VehicleStatus = (eVehicleStatus)i_NewStatus;
            }
            else
            {
                throw new ArgumentException("No Such An Option");
            }
        }
    }
}