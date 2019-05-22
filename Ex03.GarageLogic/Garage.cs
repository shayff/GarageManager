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
        public void ShowLicenseNumbers()
        {
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
                //NT throw exception Vehicle not exist
            }
        }

        //Request 4
        public void InflatingWheelToMaxs(string i_LicenseNumber)
        {
            if (IsLicenseNumberInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].m_Vehicle.InflatingWheelsToMax();
            }
            else
            {
                //NT throw exception Vehicle not exist
            }

        }

        //Request 5
        public void AddFuelToFuelVehicles(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLiterToAdd)
        { }

        //Request 6
        public void ChargingElectricVehicle(string i_LicenseNumber, float i_EnergyToAdd)
        { }

        //Request 7
        public void ShowAllDetails()
        {
            
        }
        public bool IsLicenseNumberInGarage(string i_LicenseNumberToCheck)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumberToCheck);             
        }

        public List<string> GetVehiclesInGarage()
        {
            return new List<string>(m_VehiclesInGarage.Keys);
        }

        public List<string> GetVehiclesInGarageByStatus(VehicleInGarage.eVehicleStatus i_VehicleStatusToCompare)
        {
            List<string> ListOfVehiclesByStatus = new List<string>();
            foreach (KeyValuePair<string, VehicleInGarage> vehicle in m_VehiclesInGarage)
            {
                if(vehicle.Value.VehicleStatus == i_VehicleStatusToCompare)
                {
                    ListOfVehiclesByStatus.Add(vehicle.Key);
                }
            }
            return ListOfVehiclesByStatus;
        }
    }
}