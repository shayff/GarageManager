using System;
using System.Collections.Generic;
using System.Text;


namespace Ex03.GarageLogic
{
    public class Garage
    {
        const int k_ElectricityEnumNum = 4;
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public Dictionary<string, VehicleInGarage> VehiclesInGarage
        {
            get { return m_VehiclesInGarage; }
        }

        // Request 1
        public void InsertVehicleToGarage(string ownerName, string phoneNumber, Vehicle newVehicle)
        {
            VehicleInGarage newVehicleInGarage = new VehicleInGarage(ownerName, phoneNumber, newVehicle);
            m_VehiclesInGarage.Add(newVehicle.LicenseNumber, newVehicleInGarage);
        }

        // Request 2 
        public List<string> GetVehiclesInGarage()
        {
            return new List<string>(m_VehiclesInGarage.Keys);
        }

        // Request 3
        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleInGarage.eVehicleStatus i_NewStatus)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        // Request 4
        public void InflatingWheelToMax(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].InflatingWheelsToMax();
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        // Request 5
        public void FillFuelToFuelVehicles(string i_LicenseNumber, int i_FuelType, float i_FuelLiterToAdd)
        {
            m_VehiclesInGarage[i_LicenseNumber].FillEnergy(i_FuelType, i_FuelLiterToAdd);
        }

        // Request 6
        public void ChargingElectricVehicle(string i_LicenseNumber, float i_EnergyToAdd)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].FillEnergy(k_ElectricityEnumNum, i_EnergyToAdd);
            }

            else
            {
                throw new KeyNotFoundException();
            }

        }

        // Request 7
        public string ShowAllDetails(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                return m_VehiclesInGarage[i_LicenseNumber].ToString();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public bool IsLicenseNumberInGarage(string i_LicenseNumberToCheck)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumberToCheck);
        }

        public void GetDetailsEnergyCapacity(string i_LicenseNumber, out float o_CurrentEnergyCapacity, out float o_MaxEnergyCapacity)
        {
            o_CurrentEnergyCapacity = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.CurrentEnergyCapacity;
            o_MaxEnergyCapacity = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.MaxEnergyCapacity;
        }

        public List<string> GetVehiclesInGarageByStatus(int i_IntVehicleStatusToCompare)
        {
            if (Enum.IsDefined(typeof(VehicleInGarage.eVehicleStatus), i_IntVehicleStatusToCompare))
            {
                VehicleInGarage.eVehicleStatus vehicleStatusToCompare = (VehicleInGarage.eVehicleStatus)i_IntVehicleStatusToCompare;

                List<string> listOfVehiclesByStatus = new List<string>();
                foreach (KeyValuePair<string, VehicleInGarage> vehicle in m_VehiclesInGarage)
                {
                    if (vehicle.Value.VehicleStatus == vehicleStatusToCompare)
                    {
                        listOfVehiclesByStatus.Add(vehicle.Key);
                    }
                }

                return listOfVehiclesByStatus;
            }
            else
            {
                throw new FormatException();
            }

        }

    }
}