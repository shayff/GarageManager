using System;
using System.Collections.Generic;
using System.Text;



namespace Ex03.GarageLogic
{
    public class Garage
    {
        //private static LinkedList<Vehicle> m_Vehicles;
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        //Request 1
        public void InsertVehicleToGarage()
        {

        }

        //Request 2 
        public List<string> GetVehiclesInGarage()
        {
            return new List<string>(m_VehiclesInGarage.Keys);
        }

        public List<string> GetVehiclesInGarageByStatus(VehicleInGarage.eVehicleStatus i_VehicleStatusToCompare)
        {
            List<string> ListOfVehiclesByStatus = new List<string>();
            foreach (KeyValuePair<string, VehicleInGarage> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Value.VehicleStatus == i_VehicleStatusToCompare)
                {
                    ListOfVehiclesByStatus.Add(vehicle.Key);
                }
            }
            return ListOfVehiclesByStatus;
        }

        //Request 3
        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleInGarage.eVehicleStatus i_NewStatus)
        {
            //NT should i check if the new status can change ?
            if(IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        //Request 4
        public void InflatingWheelToMax(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].m_Vehicle.InflatingWheelsToMax();
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        //Request 5
        public void FillFuelToFuelVehicles(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLiterToAdd)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber)) 
            {
                m_VehiclesInGarage[i_LicenseNumber].m_Vehicle.FillEnergy(i_FuelType, i_FuelLiterToAdd);
            }

            else
            {
                throw new KeyNotFoundException();
            }
        }

        //Request 6
        public void ChargingElectricVehicle(string i_LicenseNumber, float i_EnergyToAdd)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].m_Vehicle.FillEnergy(eFuelType.Electricity,i_EnergyToAdd);
            }

            else
            {
                throw new KeyNotFoundException();
            }

        }

        //Request 7
        public string ShowAllDetails(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                return m_VehiclesInGarage[i_LicenseNumber].VehicleInGarageDetails();
            }
           else
            {
                throw new KeyNotFoundException();
            }
            return "";
        }
        
        public bool IsLicenseNumberInGarage(string i_LicenseNumberToCheck)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumberToCheck);             
        }

       
    }
}