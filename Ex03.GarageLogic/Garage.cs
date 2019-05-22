using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static LinkedList<Vehicle> m_Vehicles;

        /*Properties*/
        public LinkedList<Vehicle> Vehicles
        {
            set { m_Vehicles=value; }
            get { return m_Vehicles; }
        }


        //Request 1
        public void InsertVehicleToGarage()
        {

        }

        //Request 2
        public void ShowLicenseNumbers()
        {
        }

        //Request 3
        public void ChangeConditionOfCar(string i_LicenseNumber, VehicleInGarage.eVehicleStatus i_NewStatus)
        {
            //Need to find by license number

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.VehicleTicket.VehicleStatus = i_NewStatus;
                }
            }
        }

        //Request 4
        public void InflatingWheelToMax(string i_LicenseNumber)
        {
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
        public static bool IsLicenseNumberInGarage(string i_LicenseNumberToCheck)
        {
            return m_Vehicles.Equals(new Vehicle(i_LicenseNumberToCheck));
        }
        
    }
}