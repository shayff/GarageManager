using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicle
    {
        public enum eVehicleTypes
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelTruck
        }

        /*
        public static Vehicle Create(string i_LicenseNumber, eVehicleTypes i_VehicleType)
        {
            Vehicle newVehicle ;
            switch (i_VehicleType)
            {
                case eVehicleTypes.FuelCar:
                    {
                        newVehicle = new Car(i_LicenseNumber);
                        break;
                    }
             }
            return newVehicle;
        }
        */
    }
}